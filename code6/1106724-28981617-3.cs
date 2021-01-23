             [MessageContract]
             public class FileInfo
             {
                  [MessageHeader(MustUnderstand = true)]
                   public string FileName { get; set; }
                   [MessageHeader(MustUnderstand = true)]
                   public long Length { get; set; }
                   [MessageBodyMember(Order = 1)]
                   public Stream Stream { get; set; }
              }
