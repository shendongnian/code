    public partial class App : Application
    {
        [STAThread]
        public static void Main()
        {
            App app = new App();
            app.InitializeComponent();
            app.ShowWindow1();
            app.ShowWindow1(); // show second time same window (new instance)
        }
        public void ShowWindow1()
        {
            // show window1 in separate method, so that instance will be deleted after method ends
            Window1 window1 = new Window1();
            // optional (as it seems)
            // MainWindow = window1
            widow1.Show();
        }
    }
