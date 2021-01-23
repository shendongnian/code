    using System;
    using System.Threading.Tasks;
    using Windows.ApplicationModel.Background;
    using Windows.Storage.Streams;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Markup;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Media.Imaging;
    using Windows.Graphics.Imaging;
    using Windows.UI.Notifications;
    using Windows.Data.Xml.Dom;
    
    namespace BackgroundTask
    {
        public sealed class AppTileUpdater : XamlRenderingBackgroundTask
        {
            protected override void OnRun(Windows.ApplicationModel.Background.IBackgroundTaskInstance taskInstance)
            {
                BackgroundTaskDeferral _deferral = taskInstance.GetDeferral();
                System.Diagnostics.Debug.WriteLine("OnRun called!");
                UpdateTileAsync(_deferral);
            }
    
            private async Task<string> ReadFile()
            {
                var folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
                var file = await folder.GetFileAsync("customTile.xml");
                string szCustomTileXML = await Windows.Storage.FileIO.ReadTextAsync(file);
                return szCustomTileXML;
            }
            private async void UpdateTileAsync(BackgroundTaskDeferral deferral)
            {
                
                var folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
                var file = await folder.GetFileAsync("customTile.xml");
                string szCustomTileXML = await Windows.Storage.FileIO.ReadTextAsync(file);
    
                Border tile = XamlReader.Load(szCustomTileXML) as Border;
    
                if (null != tile)
                {
                    tile.Background = new SolidColorBrush(Windows.UI.Colors.Orange);
                    Grid grid = tile.Child as Grid;
                    TextBlock text = grid.FindName("Timestamp") as TextBlock;
                    text.Text = DateTime.Now.ToString("hh:mm:ss");
                    text = grid.FindName("TimeZone") as TextBlock;
                    text.Text = TimeZoneInfo.Local.DisplayName;
    
                    Image logo = grid.FindName("LogoImage") as Image;
                    var img = new BitmapImage() { CreateOptions = BitmapCreateOptions.None };
                    img.UriSource = new Uri("ms-appx:///Assets/acorn.png");
    
                    RenderTargetBitmap rtb = new RenderTargetBitmap();
                    await rtb.RenderAsync(tile, 150, 150);
                    IBuffer pixels = await rtb.GetPixelsAsync();
                    DataReader dReader = Windows.Storage.Streams.DataReader.FromBuffer(pixels);
                    byte[] data = new byte[pixels.Length];
                    dReader.ReadBytes(data);
    
                    var outputFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.CreateFileAsync("UpdatedLiveTile.png", Windows.Storage.CreationCollisionOption.ReplaceExisting);
                    var outputStream = await outputFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
                    BitmapEncoder enc = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, outputStream);
                    enc.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied, (uint)rtb.PixelWidth, (uint)rtb.PixelHeight, 96,96, data);
                    await enc.FlushAsync();                
                }
                var TileMgr = TileUpdateManager.CreateTileUpdaterForApplication();
                TileMgr.Clear();
                var tileTemplate = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Image);
                var tileImageAttributes = tileTemplate.GetElementsByTagName("image");
                XmlElement tmp = tileImageAttributes[0] as XmlElement;
                tmp.SetAttribute("src", "UpdatedLiveTile.png");
                var notification = new TileNotification(tileTemplate);
                TileMgr.Update(notification);
                deferral.Complete();
            }
    
            public void Run(IBackgroundTaskInstance taskInstance)
            {
                System.Diagnostics.Debug.WriteLine("Run called!");
                OnRun(taskInstance);
            }
        }
    }
