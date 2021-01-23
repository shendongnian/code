    [TestClass]
    public class View_Test
    {
        [TestMethod]
        public void Test()
        {
            //set initial ResourceAssembly so we can load the App
            Application.ResourceAssembly = Assembly.GetAssembly(typeof (App));
            //load app
            var app = (App) Application.LoadComponent(new Uri("App.xaml", UriKind.Relative));
            //load window and assign to app
            var mainWindow = (Window) Application.LoadComponent(new Uri("MainWindow.xaml", UriKind.Relative));
            app.MainWindow = mainWindow;
            //load view and assign to window content
            var view = (UserControl) Application.LoadComponent(new Uri("View.xaml", UriKind.Relative));
            mainWindow.Content = view;
            //show the window
            mainWindow.Show();
        }
    }
