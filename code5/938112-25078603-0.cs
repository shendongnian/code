    public class CustomUriMapper: UriMapperBase
    {
        public override Uri MapUri(Uri uri)
        {
            // Break into this point to detect the incoming uri and be sure
            // to return a valid xaml page if tempuri contains your protocol name
            string tempUri = uri.ToString();
            string mappedUri = string.Empty;
            // Search for a specific deep link URI keyword
            if (tempUri.Contains("msftappid"))
            {
                // Launch to the mainpage xaml.
                return new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute);
            }
            // Otherwise perform normal launch.
            Debug.WriteLine("Normal launch detection");
            return uri;
        }
    }
