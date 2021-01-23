        public class MyUriMapper : UriMapperBase
        {
            public override Uri MapUri(Uri uri)
            {
                if (uri.OriginalString == "/StartUp")
                {
                    if (!this.dataOperations.IsLoggedIn())
                    {
                        return Login.Path;
                    }
                    else
                    {
                        return Main.Path;
                    }
                }
                return uri;
            }
        }
