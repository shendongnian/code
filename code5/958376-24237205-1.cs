    `[DataContract]
    public class Customer
    {
        [DataMember]
        public string CustName
        {
           get
           { 
                return this._custName;
           }
           set
           {
                if(string.IsNullOrEmpty(value)) 
                   throw new MyValidationException();
                else
                   this._custName=value;
           }
        }
    }`
   
