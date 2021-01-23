    public class FStreamService : Service
    {
        public object Get(FStream request)
        {
            var filePath = @"c:\test.xml";
            var compressFileResult = new CompressedFileResult(filePath); //CompressedResult in ServiceStack.Common.Web.CompressedFileResult
            compressFileResult.WriteTo(Response.OutputStream);
            Response.EndRequest();
            //  ...cleanup code...
        }
    }
