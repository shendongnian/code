    public class ResourceInterceptor : IResourceInterceptor
    {
        public bool NoImages { get; set; }
        private static string[] _imagesFileTypes = { ".png", ".jpg", ".jpeg", ".gif", ".bmp" };
        public ResourceResponse OnRequest(ResourceRequest request)
        {
            string ext = System.IO.Path.GetExtension(request.Url.ToString()).ToLower();
            if (NoImages && _imagesFileTypes.Contains(ext))
            {
                request.Cancel();
            }
            return null;
        }
        public bool OnFilterNavigation(NavigationRequest request)
        {
            return false;
        }
    }
    ...
    ResourceInterceptor ResInt = new ResourceInterceptor();
    WebCore.ResourceInterceptor = ResInt;
