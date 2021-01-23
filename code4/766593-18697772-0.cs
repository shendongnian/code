    public class YourUriMapper : UriMapperBase
    {
        public override Uri MapUri(Uri uri)
        {
            if (uri.OriginalString == "/PageA.xaml")
            {
                if (AppSettings.FirstRun == false)
                {
                    uri = new Uri("/PageB.xaml", UriKind.Relative);
                }
                else
                {
                    uri = new Uri("/PageA.xaml", UriKind.Relative);
                }
            }
            return uri;
        }
    }
