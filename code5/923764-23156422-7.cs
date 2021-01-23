        [DataContract]
        public class FileInfo
        {
            [DataMember]
            public string FileName;
            [DataMember]
            public string Mode;
            [DataMember]
            public long? ID;
            [DataMember]
            public byte[] FileByte;
        }
        [DataContract]
        public class ResultInfo
        {
            [DataMember]
            public string Result;
        }
