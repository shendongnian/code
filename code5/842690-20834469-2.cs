    [TestClass]
    public class View_Test
    {
        [TestMethod]
        public void Test()
        {
            Application.ResourceAssembly = Assembly.GetAssembly(typeof (App));
            var app = new App();
            app.InitializeComponent();
            var mainWindow = new MainWindow();
            app.MainWindow = mainWindow;
            var view = new View();
            mainWindow.Content = view;
            mainWindow.Show();
        }
    }
