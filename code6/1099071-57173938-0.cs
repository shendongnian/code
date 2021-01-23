    namespace YourApp.ViewModels
    {
        public class CurrentPageViewModel
        {
            public ICommand BackToPage  {get; private set; }
    
            public CurrentPageViewModel()
            {
                BackToPage = new Command(async () => {
                  await  Application.Current.MainPage.Navigation.PushModalAsync(new MainPage());
                });
            }
        }
    }
