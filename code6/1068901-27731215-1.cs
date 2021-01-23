    class Program2
    {
        static void Main(String[] args)
        {
            String str = args[0];//check for length and handle error scenarios.
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(str));
            //deserialize
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(UserData));
                UserData data = (UserData)ser.ReadObject(ms);
                Console.WriteLine(data.Dir + ", " + data.FileFilter + ", " + data.OutPutFile );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    [DataContract]
    class UserData
    {
        [DataMember]
        public string Dir { get; set; }
        [DataMember]
        public string FileFilter { get; set; }
        [DataMember]
        public string OutPutFile { get; set; }
    }
