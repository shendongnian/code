    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace GridTest
    {
        /// <summary>
        /// Interaction logic for Window3.xaml
        /// </summary>
        public partial class Window3 : Window
        {
            private static List<string> SourceFiles = new List<string>();
            private static readonly string SourceDir = @"C:\TestFiles\Images\";
            private static readonly string DestinationDir = @"C:\Files\Images\3_5x5\";
            public Window3()
            {
                InitializeComponent();
                this.Loaded += Window3_Loaded;
            }
            void Window3_Loaded(object sender, RoutedEventArgs e)
            {
            }
    
            async Task DoWorkAsync(CancellationToken token)
            {
                int transferCount;
                for (transferCount = 0; transferCount < SourceFiles.Count; transferCount++)
                {
                    token.ThrowIfCancellationRequested();
                    var fileName = System.IO.Path.GetFileName(SourceFiles[transferCount]);
                    var destFile = System.IO.Path.Combine(DestinationDir, fileName);
                    System.IO.File.Copy(SourceFiles[transferCount], destFile, true);
                    System.IO.File.Delete(SourceFiles[transferCount]);
                    Console.WriteLine(string.Format("Total Files: {0} Number of files transferred: {1}", SourceFiles.Count, transferCount + 1));
                    transferCount += 1;
    
                    await TaskEx.Delay(3000, token); // 3s delay
                }
                Console.WriteLine(string.Format("Total number of files transferred: {0}. Transfer Completed", transferCount + 1));
            }
    
            CancellationTokenSource _cts;
            Task _task;
    
            private void Start_Click(object sender, RoutedEventArgs e)
            {
                if (_cts != null)
                    _cts.Cancel();
                _cts = new CancellationTokenSource();
                _task = TaskEx.Run(() => DoWorkAsync(_cts.Token), _cts.Token);
            }
    
            private void Stop_Click(object sender, RoutedEventArgs e)
            {
                if (_cts != null)
                    _cts.Cancel();
            }
        }
    }
