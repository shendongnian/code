    public class ProxiedCdnBundle : Bundle
    {
        private readonly string _cdnHost;
        public ProxiedCdnBundle(string virtualPath, string cdnHost = "")
            : base(virtualPath)
        {
            _cdnHost = cdnHost;
        }
        public override BundleResponse ApplyTransforms(BundleContext context, string bundleContent, IEnumerable<BundleFile> bundleFiles)
        {
            var response = base.ApplyTransforms(context, bundleContent, bundleFiles);
            if (context.BundleCollection.UseCdn && !String.IsNullOrWhiteSpace(_cdnHost))
            {
                string path = System.Web.VirtualPathUtility.ToAbsolute(context.BundleVirtualPath);
                base.CdnPath = string.Format("{0}{1}?v={2}", _cdnHost, path, GetBundleHash(response));
            }
            return response;
        }
        
        private static string GetBundleHash(BundleResponse response)
        {
            using (var hashAlgorithm = CreateHashAlgorithm())
            {
                return HttpServerUtility.UrlTokenEncode(hashAlgorithm.ComputeHash(Encoding.Unicode.GetBytes(response.Content)));
            }
        }
        private static SHA256 CreateHashAlgorithm()
        {
            if (CryptoConfig.AllowOnlyFipsAlgorithms)
            {
                return new SHA256CryptoServiceProvider();
            }
            return new SHA256Managed();
        }
    }
