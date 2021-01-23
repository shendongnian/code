    [DataContract(Namespace = "http://Foo.bar.car")]
    public class GetPolicyData
    {
        [DataMember]
        public request request { get; set; }
    }
    
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/Foo.bar.car.Model.Policy")]
    public class request
    {
        ///<summary>
        /// Define request parameter for SOAP API to retrieve selective Policy level data
        /// </summary>
        [DataMember]
        public string REQ_POL_NBR { get; set; }
    }
   
