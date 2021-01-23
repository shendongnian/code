    public class XmlFileFilter : Java.Lang.Object, IFilenameFilter
    {
        public bool Accept(File dir, string filename)
        {
            return filename.ToLower().EndsWith(".xml");
        }
    }
