    [DataContract]
    public class ListTestClassTwo
    {
       [DataMember]
       public List<TestClassTwo> Member { get; set; }
       public ListTestClassTwo()
       {
            Member = new List<TestClassTwo>();
       }
    }
