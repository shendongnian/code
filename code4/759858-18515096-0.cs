        [DataContract]
        public class DetailedData
        {
            [DataMember(Name="path")]
            public string Path { get; set; }
            [DataMember(Name = "minVersion")]
            public int MinVersion { get; set; }
            [DataMember(Name = "maxVersion")]
            public int MaxVersion { get; set; }
        }
        [DataContract]
        public class Data
        {
            [DataMember(Name = "foo.hugo.info")]
            public DetailedData Info { get; set; }
            [DataMember(Name = "foo.Fritz.Task")]
            public DetailedData Task { get; set; }
        }
        [DataContract]
        public class RootObject
        {
            [DataMember(Name = "data")]
            public Data Data { get; set; }
            [DataMember(Name = "success")]
            public bool Success { get; set; }
        }
        static void Main(string[] args)
        {
            string json = "...";
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(RootObject));
            RootObject obj = (RootObject)js.ReadObject(new MemoryStream(Encoding.Unicode.GetBytes(json)));
            Console.WriteLine(obj.Data.Task.MaxVersion); 
        }
