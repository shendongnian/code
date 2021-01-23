    public class BrowserSelectionVM : ViewModelBase
    {
        public BrowserSelectionVM()
        {
            Messenger.Default.Register<System.Windows.Visibility>(this,
                "BrowserSelectionVisible",
                msg => { Console.WriteLine(msg); });
        }
    }
