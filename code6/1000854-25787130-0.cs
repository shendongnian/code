    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Stream GetMapPicture(int id, double x);
    …
     public class Service1 : IService1
     {
        [WebGet(ResponseFormat = WebMessageFormat.Json, 
            UriTemplate = "MapPicture/?id={id}&x={x}")]
        public Stream GetMapPicture(int id, double x)
        {
