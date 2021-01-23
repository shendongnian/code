         [DataContractAttribute]
      public class MyDataDtoFault
      { 
        private string report;
    
        public MyDataDtoFault(string message)
        {
          this.report = message;
        }
    
        [DataMemberAttribute]
        public string Message
        {
          get { return this.report; }
          set { this.report = value; }
        }
      }  
    
        [OperationContract]
        [FaultContract(typeof(MyDataDtoFault))]
        public MyDataDto GetData(string filter)
        {
           MyData data = repository.GetData(filter);
            if (data==null)  
                 throw new MyDataDtoFault("No result Was found");  
           return new MyDataDto(data);
        }
      
