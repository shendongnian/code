    public class MyClass
    {
        [JsonIgnore]
        public Int64 MyInt {get; set;}
        [JsonProperty("MyInt")]
        public Int64 MyEncryptedInt
        {
            get { return Encrypt(MyInt); }
            set { MyInt = Decrypt(value); }
        }
    }
