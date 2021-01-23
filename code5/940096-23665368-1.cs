    public static OkFileDownloadResult Download(this ApiController controller, string path, string contentType)
        {
            string downloadFileName = Path.GetFileName(path);
            return Download(controller, path, contentType, downloadFileName);
        }
        public static OkFileDownloadResult Download(this ApiController controller, string path, string contentType, string downloadFileName)
        {
            if (controller == null)
            {
                throw new ArgumentNullException("controller");
            }
            return new OkFileDownloadResult(path, contentType, downloadFileName, controller);
        }
