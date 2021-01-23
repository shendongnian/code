    public sealed class ApplicationBar : IApplicationBar
    {
        public ApplicationBar();
        public Color BackgroundColor { get; set; }
        public IList Buttons { get; }
        public double DefaultSize { get; }
        public Color ForegroundColor { get; set; }
        public bool IsMenuEnabled { get; set; }
        public bool IsVisible { get; set; }
        public IList MenuItems { get; }
        public double MiniSize { get; }
        public ApplicationBarMode Mode { get; set; }
        public double Opacity { get; set; }
        public event EventHandler<ApplicationBarStateChangedEventArgs> StateChanged;
    }
