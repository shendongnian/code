    namespace YourApp.ViewModels
    {
        public class MainPageViewModel 
        {
            public ICommand BackToMain { get; private set; }
    
            public MainPageViewModel()
            {
                BackToMain = new Command(async () => {
                    await Application.Current.MainPage.Navigation.PopAsync();
                });
            }
        }
    }
