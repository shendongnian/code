    [MessageContract]
    public class UploadFileRequest
    {
            [MessageHeader]
            public string filePath;
            [MessageBodyMember]
            public Stream bytes;
    }
    [ServiceContract]
    public interface IStreamTest
    {
          [OperationContract]
          Stream GetStream(string filePath);
          [OperationContract]
           void PutStream(UploadFileRequest request);
    }
