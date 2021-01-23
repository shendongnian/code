    public class Localized : INotifyPropertyChanged
    {
        public ILabels Labels { ... }
    }
    // defines all the keys that you use in your .resx files
    public interface ILabels
    {
        string MainWindowHeader { get; }
        string OkLabel { get; }
        ...
    }
    EnglishLabels : ILabels;
    GermanLabels: ILabels;
