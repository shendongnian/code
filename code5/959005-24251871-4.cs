    public class MyPage : ContentPage
    {
        public MyPage()
        {
            //do work to initialize MyPage 
        }
    
        public void LogIn(object sender, EventArgs eventArgs)
        {
            bool isAuthenticated = false;
            string accessToken = string.Empty;
    
            //do work to use authentication API to validate users
    
            if(isAuthenticated)
            {
                App.UserPreferences.SetString("AccessToken", accessToken);
            }
        }
    }
