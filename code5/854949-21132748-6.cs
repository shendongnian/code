    public interface IApplicationBar
    {
        Color BackgroundColor { get; set; }
        IList Buttons { get; }
        double DefaultSize { get; }
        Color ForegroundColor { get; set; }
        bool IsMenuEnabled { get; set; }
        bool IsVisible { get; set; }
        IList MenuItems { get; }
        double MiniSize { get; }
        ApplicationBarMode Mode { get; set; }
        double Opacity { get; set; }
        event EventHandler<ApplicationBarStateChangedEventArgs> StateChanged;
    }
