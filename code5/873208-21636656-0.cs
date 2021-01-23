    [DataContract]
    public class ProfileType
    {
        [DataMember]
        public int ProfileTypeIDT { get; set; }
        [DataMember]
        public string SingularName { get; set; }
        [DataMember]
        public string PluralName { get; set; }
        [DataMember]
        public ProfileField[] Fields { get; set; }
    }
    
    [DataContract]
    public class ProfileField
    {
        [DataMember]
        public int ProfileFieldIDT { get; set; }
        [DataMember]
        public int ProfileTypeIDT { get; set; }
        [DataMember]
        public string FieldName { get; set; }
        [DataMember]
        public string DataType { get; set; }
        [DataMember]
        public int Length { get; set; }
    }
    byte[] byteArray = Encoding.Unicode.GetBytes(jsonString);
    MemoryStream stream = new MemoryStream(byteArray);
    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ProfileType[]));
    ProfileType[] profileTypes = (ProfileType[])serializer.ReadObject(stream);
