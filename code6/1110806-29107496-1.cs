    public interface IDialogWindow
    {
        void Show();
    }
    public interface IDetailsWindow : IWindow
    {
    }
    public class DetailsWindow : Window, IDetailsWindow
    {
        // The Show() method from IDialogWindow is automatically implemented
        // by the WPF Window class
    }
