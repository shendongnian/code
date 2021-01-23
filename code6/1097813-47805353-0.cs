    public class FileResourceHandlerFactory : ISchemeHandlerFactory {
        private string scheme, host, folder, default_filename;
        public string Scheme => scheme;
        public FileResourceHandlerFactory(string scheme, string host, string folder, string default_filename = "index.html") {
            this.scheme = scheme;
            this.host = host;
            this.folder = folder;
            this.default_filename = default_filename;
        }
        private string get_content(Uri uri, out string extension) {
            var path = uri.LocalPath.Substring(1);
            path = string.IsNullOrWhiteSpace(path) ? this.default_filename : path;
            extension = Path.GetExtension(path);
            return File.ReadAllText(Path.Combine(this.folder, path));
        }
        IResourceHandler ISchemeHandlerFactory.Create(IBrowser browser, IFrame frame, string schemeName, IRequest request) {
            var uri = new Uri(request.Url);
            return ResourceHandler.FromString(get_content(uri, out var extension), extension);
        }
    }
