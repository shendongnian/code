    public class DownloadData
    {
        public Uri DownloadUri;
        public string TargetPath;
        public DownloadData(Uri downloadUri, string targetPath)
        {
            this.DownloadUri = downloadUri;
            this.TargetPath = targetPath;
        }
    }
