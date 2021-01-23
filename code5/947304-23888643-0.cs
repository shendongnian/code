    public class MyClass
    {
        private string fullName;
        [DataMember]
       public string FullName
       {
           get { return fullName; }
           set { fullName = value; }
       }
    }
