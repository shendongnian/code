    public class UploadMultipartMediaTypeFormatter : MediaTypeFormatter
    {
        UploadMultipartMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("multipart/form-data"));
        }
    }
