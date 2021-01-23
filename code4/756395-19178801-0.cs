    namespace MyCompany.Factories
    {
        using System.Threading;
        using MyCompany.Views;
        using MyCompany.ViewModels;
        public static class SplashScreenFactory
        {
            public static SplashScreenViewModel CreateSplashScreen(
                string header, string title, string initialLoadingMessage, int minimumMessageDuration)
            {
                var viewModel = new SplashScreenViewModel(initialLoadingMessage, minimumMessageDuration)
                {
                    Header = header,
                    Title = title
                };
                Thread thread = new Thread(() =>
                {
                    var splashScreen = new SplashScreenView(viewModel);
                    splashScreen.Topmost = true;
                    splashScreen.Show();
                    splashScreen.Closed += (x, y) => splashScreen.Dispatcher.InvokeShutdown();
                    System.Windows.Threading.Dispatcher.Run();
                });
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true;
                thread.Start();
                
                return viewModel;
            }
        }
    }
