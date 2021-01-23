    public class ViewModel
    {
        public ViewModel()
        {
            Icons = new ObservableCollection<ImageSource>();
        }
        public ObservableCollection<ImageSource> Icons { get; set; }
        public void LoadIcons()
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                foreach (var path in paths)
                {
                    var image = System.Drawing.Icon.ExtractAssociatedIcon(mypath).IconToImageSource();
                    image.Freeze();
                    Application.Current.Dispatcher.Invoke(
                        new Action(() => Icons.Add(image)));
                }
            });
        }
    }
