    //to serialize 
            SerializeHelper.Serialize("your filename" ,new AllUserCollections());
    // deserialize
            var usertCollections = SerializeHelper.Deserialize<AllUserCollections>("yourfile name"); 
    //code 
     [DataContract]
        public class AllUserCollections
        {
            public List<UserCollection> UserCollections { get; set; }
    
            public AllUserCollections()
            {
                this.UserCollections = new List<UserCollection>();
            }
        }
        [DataContract()]
        public class UserCollection
        {
             [DataMember]
            public string UserGroup { get; set; }
    
             [DataMember]
            public Dictionary<int, User> Users { get; set; }
    
            public UserCollection(string userGroup)
            {
                this.UserGroup = userGroup;
                this.Users = new Dictionary<int, User>();
            }
        }
        [DataContract()]
        public class User
        {   [DataMember]
            public int ID { get; set; }
             [DataMember]
            public string Name { get; set; }
             [DataMember]
            public string Location { get; set; }
             [DataMember]
            public AgeGroup UserAgeGroup { get; set; }
        }
         [DataContract]
        public enum AgeGroup
        {
            Twenties,
            Thirties,
            Fourties,
        }
        public  static class  SerializeHelper
        {
            public static void Serialize<T>(string fileName, T obj)
            {
                FileStream writer = new FileStream(fileName, FileMode.Create);
                DataContractSerializer ser =
                    new DataContractSerializer(typeof(T));
                ser.WriteObject(writer, obj);
                writer.Close();
            }
    
            public static T Deserialize<T>(string fileName)
            {
                FileStream fs = new FileStream(fileName,
                FileMode.Open);
                XmlDictionaryReader reader =
                    XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                DataContractSerializer ser = new DataContractSerializer(typeof(T));
                T des =
                    (T)ser.ReadObject(reader, true);
                reader.Close();
                fs.Close();
                return des;
            }
        }
