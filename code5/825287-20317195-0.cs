    public sealed Class MyDataResults
    {
       public MyDataResults()
       {
          this.Success = false;
          this.FailureInformation = string.Empty;
          this.Results = new MyData();
       }
    
       public bool Success {get; set;}
       public MyData Results {get; set;}
       public string FailureInformation {get; set;}
    }
