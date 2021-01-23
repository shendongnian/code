    public interface IDialogWindow
    {
        void Show();
    }
    public interface IDetailsWindow : IDialogWindow
    {
    }
    public class DetailsWindow : Window, IDetailsWindow
    {
        // The Show() method from IDialogWindow is automatically implemented
        // by the WPF Window class
    }
