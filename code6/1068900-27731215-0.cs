    class Program2
    {
        static void Main(String[] args)
        {
            String str = args[0];//check for length and handle error scenarios.
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(userData));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(str));
            //deserialize
            userData data = (userData)ser.ReadObject(ms);
            Console.WriteLine(data.Dir + ", " + data.FileFilter + ", " + data.OutPutFile );
        }
    }
    [DataContract]
    class userData
    {
        [DataMember]
        public string Dir { get; set; }
        [DataMember]
        public string FileFilter { get; set; }
        [DataMember]
        public string OutPutFile { get; set; }
    }
