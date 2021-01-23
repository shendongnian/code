    [DataContract(IsReference = true)]
    public class test 
    {
        // DO NOT include this in serialization
        private static object _lockObject = new object();
        // This dummy object stands in for _lockObject for purposes of serialization
        // but is not referenced elsewhere in the code
        [DataMember(Name = "_lockObject")]
        private object dummy = new object();
        [DataMember]
        private int num;
    }
