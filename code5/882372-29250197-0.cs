    public class AppUriMapper : UriMapperBase
    {
        public static bool IsNavigating = false;
        public override Uri MapUri(Uri uri)
        {
            var endUri = uri;
            if (IsNavigating)
            {
                IsNavigating = false;
                //blabla......
            }
            System.Diagnostics.Debug.WriteLine("goto: [origin] {0} [dest] {1}", uri, endUri);
            return endUri;
        }
    }
