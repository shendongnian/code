    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using YoutubeExtractor;
    
    namespace WpfApplication1
    {
        public partial class MainWindow
        {
            public MainWindow() {
                InitializeComponent();
            }
    
            private async void Button_Click(object sender, RoutedEventArgs e) {
                string videoUrl = @"https://www.youtube.com/watch?v=5aXsrYI3S6g";
                await DownloadVideoAsync(videoUrl);
            }
    
            private Task DownloadVideoAsync(string url) {
                return Task.Run(() => {
                    IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(url);
                    VideoInfo videoInfo = videoInfos.FirstOrDefault();
                    if (videoInfo != null) {
                        if (videoInfo.RequiresDecryption) {
                            DownloadUrlResolver.DecryptDownloadUrl(videoInfo);
                        }
    
                        string savePath =
                            Path.Combine(
                                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                                Path.ChangeExtension("myVideo", videoInfo.VideoExtension));
                        var downloader = new VideoDownloader(videoInfo, savePath);
                        downloader.DownloadProgressChanged += downloader_DownloadProgressChanged;
                        downloader.Execute();
                    }
                });
            }
    
            private void downloader_DownloadProgressChanged(object sender, ProgressEventArgs e) {
                Dispatcher.BeginInvoke((Action) (() => {
                    double progressPercentage = e.ProgressPercentage;
                    ProgressBar1.Value = progressPercentage;
                    TextBox1.Text = string.Format("{0:F} %", progressPercentage);
                }));
            }
        }
    }
