    public interface MyService
    {
        //stream video from camera
        [WebGet(UriTemplate = "video/preview")]
        [OperationContract]
        Bitmap VideoPreview();     
    }
    public class MyServiceImpl : MyService
    {
        public Bitmap VideoPreview()
        {
            // code to get video etc...
            WebOperationContext.Current.OutgoingResponse.Headers[HttpResponseHeader.ContentType] = "video/x-msvideo";
        }     
}
