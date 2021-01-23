    public partial class MainWindow : Window
    {
        private MyViewModel ViewModel;
        public MainWindow()
        {
            ViewModel = new MyViewModel();
        }
        public void keyDownEventHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl)
                ViewModel.PushToTalk = true;
        }
        public void keyUpEventHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl)
                ViewModel.PushToTalk = false;
        }
    }
