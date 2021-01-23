        public partial class MainPage : PhoneApplicationPage
        {
          protected override void OnNavigatedTo(NavigationEventArgs e)
          {
              if (string.IsNullOrEmpty(App.AccessToken))
                return;
              DoThingsWithAccessToken();
          }
