    // main view registers for a message
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Messenger.Default.Register<CloseMessage>(this, message =>
            {
                // do teh stuff
            });
        }
        ...
    }
