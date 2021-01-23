    public class ServiceInterfaceTestBase
    {
        protected  IRestClient Client;
        protected void AuthenticateClient(string email, string password)
        {
            Client = new RestClient( ServiceTestAppHostBase.BaseUrl );
            var login = new RestRequest( "/auth", Method.POST );
            login.AddParameter( "username", email );
            login.AddParameter( "password", password );
            var response = Client.Execute( login );
            var cookieJar = new CookieContainer();
            if ( response.StatusCode == HttpStatusCode.OK )
            {
                var cookie = response.Cookies.FirstOrDefault();
                cookieJar.Add( new Cookie( cookie.Name, cookie.Value, cookie.Path, cookie.Domain ) );
            }
            Client.CookieContainer = cookieJar;  
        }
    }
