    [DataContract(Namespace = "MyServiceContract.Service1.ComplexObject")]
	public class ComplexObject
	{
           [DataMember(Order = 1, IsRequired = true)]
		        public String DbItem1{ get; private set; }
           [DataMember(Order = 2, IsRequired = false)]
                public ComplexBlobData DbItem2{ get; set; }
    }
