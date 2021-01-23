    <Image
        Grid.Column="0"
        Stretch="Uniform"
        Margin="5"
        Source="{Binding Preview}" />
---
    public class MainViewModel : PropertyChangedBase, IHandle<FileSelectedEvent>, IHandle<WarholFilterChangedEvent>
    {
        private readonly IEventAggregator events;
        private bool hasCustomImage = false;
        private string sourceUrl;
        [ImportingConstructor]
        public MainViewModel(IEventAggregator events)
        {
            this.events = events;
            this.events.Subscribe(this);
            this.ImageManagement = new ImageManagementViewModel(events);
            this.ImageManagement.WarholSettingsEnabled = false;
            this.Preview = new BitmapImage(new Uri("pack://application:,,,/Resources/placeholder.jpg"));
        }
        public ImageManagementViewModel ImageManagement { get; set; }
        public BitmapImage Preview { get; set; }
        public void Handle(WarholFilterChangedEvent message)
        {
            this.ApplyFilter(new WarholFilter(message));
        }
        public void Handle(FileSelectedEvent message)
        {
            this.sourceUrl = message.FilePath;
            this.hasCustomImage = true;
            this.ImageManagement.WarholSettingsEnabled = true;
            this.ApplyFilter(WarholFilter.Default);
        }
        private void ApplyFilter(WarholFilter filter)
        {
            if (this.hasCustomImage)
            {
                using (ImageFactory factory = new ImageFactory())
                {
                    factory.Load(this.sourceUrl);
                    PolychromaticParameters parameters = new PolychromaticParameters();
                    parameters.Number = filter.ColorsNumber;
                    parameters.Colors = filter.Colors.Select(c => System.Drawing.Color.FromArgb(c.R, c.G, c.B)).ToArray();
                    parameters.Thresholds = filter.Thresholds.ToArray();
                    factory.Polychromatic(parameters);
                    BitmapImage img = new BitmapImage();
                    using (MemoryStream str = new MemoryStream())
                    {
                        img.BeginInit();
                        img.CacheOption = BitmapCacheOption.OnLoad;
                        factory.Save(str);
                        str.Seek(0, SeekOrigin.Begin);
                        img.StreamSource = str;
                        img.EndInit();
                    }
                    this.Preview = img;
                }
            }
        }
    }
