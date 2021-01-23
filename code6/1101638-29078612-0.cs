        [MessageContract]
            public class RemoteFileInfo : IDisposable
            {
                [MessageHeader(MustUnderstand = true)]
                public string FileName;
          
                [MessageBodyMember]
                public System.IO.Stream FileByteStream;
    }
