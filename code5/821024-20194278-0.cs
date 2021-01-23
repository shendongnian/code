    public class ImageOnlyMultipartMemoryStreamProvider : MultipartMemoryStreamProvider
    {
        public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
        {
             var fileExtension = CommonUtils.GetFileExtension(headers.ContentDisposition.FileName);
             return _allowedExtensions == null || _allowedExtensions.Any(i => i.Equals(fileExtension , StringComparison.InvariantCultureIgnoreCase)) ? base.GetStream(parent, headers) : Stream.Null;
        }
    }
