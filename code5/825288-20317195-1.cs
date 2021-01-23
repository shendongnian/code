    [DataContract]
    public sealed Class MyDataResults
    {
       public MyDataResults()
       {
          this.Success = false;
          this.FailureInformation = string.Empty;
          this.Results = new MyData();
       }
       [DataMember(IsRequired = true)]
       public bool Success {get; set;}
       [DataMember(IsRequired = true)]
       public MyData Results {get; set;}
       [DataMember(IsRequired = true)]
       public string FailureInformation {get; set;}
    }
