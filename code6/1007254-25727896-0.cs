    /// <summary>
    /// This will be a singleton since the range is internal. You cant connect to this controller.
    /// </summary>
    [XSocketMetadata("ImageWatcher", PluginRange.Internal)]
    public class ImageWatcher : XSocketController
    {
        private ImageController imageController;
        public ImageWatcher()
        {
            imageController = new ImageController();
            var watcher = new FileSystemWatcher
            {
                Path = @"c:\temp\images\",
                NotifyFilter = NotifyFilters.LastWrite,
                Filter = "*.jpeg"
            };
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size;            
            watcher.Changed += watcher_Changed;
            watcher.EnableRaisingEvents = true;
        }
        void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                var blob = File.ReadAllBytes(e.FullPath);
                var metadata = new { filename = e.Name };
                imageController.InvokeToAll(blob, metadata, "newimage");
            }
            catch
            {
            }
        }
    }    
