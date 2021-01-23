    public class AccessTokenParser : UriMapperBase
    {
        public override void MapUri(Uri uri)
        {
            var url = uri.ToString();        
            if (url.Contains("access_token"))
            {
				App.AccessToken = ParseAccessTokenFromUrl(url); // Your code here
            }
            return new Uri("/MainPage.xaml", UriKind.Relative);
        }
    }
