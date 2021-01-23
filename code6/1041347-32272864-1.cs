      public interface INavigationPage
      {
        Type PageType { get; set; }
      }
    
      public interface INavigationService
      {
        void Navigate(INavigationPage page) { get; set; }
      }
  
    public class MyViewModel : ViewModelBase
      {
        public MyViewModel(INavigationService navigationService, INavigationPage page)
        {
          GotoPage2Command = new RelayCommand(() => { navigationService.Navigate(page.PageType); })
        }
    
        private ICommand GotoPage2Command { get; private set; }
      }
