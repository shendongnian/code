    public class ResultModel
    {
         public string Message { get; set; }
         public ResultType TypeOfResult { get; set; }
    }
  
    public Enum TypeOfResult 
    {
         Error,
         Success
    }
