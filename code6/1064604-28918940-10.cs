    public class TrayIconViewModel : ISetTrayIconInstance
    {
        public TrayIconViewModel()
        {
            
        }
        public ITrayIcon Icon { get; set; }
        public void ShowWindow()
        {
            System.Windows.Application.Current.MainWindow.Show(); //very very bad :(
        }
    }
