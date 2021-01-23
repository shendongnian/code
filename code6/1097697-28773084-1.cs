    public class EmbeddedVirtualFile : VirtualFile
    {
        private string LayoutPath = "~/...yourpath to the Layout"
        private readonly string _virtualPath;
        public EmbeddedVirtualFile(string virtualPath) : base(virtualPath)
        {
            this._virtualPath = virtualPath;
        }
        public override Stream Open()
        {
            var stream = File.Open(this.fileInfo.FullName, FileMode.Open);
            if (_virtualPath.EndsWith(".cshtml"))
            {
                var streamFixed = CorrectView(_virtualPath, stream);
                return streamFixed;
            }
            return stream;
        }
       
        private Stream CorrectView(string virtualPath, Stream stream)
        {
            var reader = new StreamReader(stream, Encoding.UTF8);
            var view = reader.ReadToEnd();
            stream.Close();
            var ourStream = new MemoryStream();
            var writer = new StreamWriter(ourStream, Encoding.UTF8);
            // Here you may add some @usings like writer.WriteLine("@using System.Web.Mvc");
            // partial views should not have a layout & viewStart/_Layout either
            if (!string.IsNullOrEmpty(LayoutPath) && !virtualPath.Contains("/_") && !virtualPath.Contains("_viewstart") && !virtualPath.Contains("_Layout"))
            {
                writer.WriteLine(string.Format("@{{ Layout = \"{0}\"; }}", LayoutPath));
            }
            writer.Write(view);
            writer.Flush();
            ourStream.Position = 0;
            return ourStream;
        }
    }
