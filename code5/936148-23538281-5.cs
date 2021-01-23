    [DataContract]
    public class OperationResult
    {
      public OperationResult()
      {
        Errors = new List<OperationError>();
        Success = true;
      }
      [DataMember]
      public bool Success { get; set; }
      [DataMember]
      public IList<OperationError> Errors { get; set; }
    }
    [DataContract(Name = "OperationResultOf{0}")]
    public class OperationResult<T> : OperationResult
    {
      [DataMember]
      public T Result { get; set; }
    }
    [DataContract]
    public class OperationError
    {
      [DataMember]
      public string ErrorCode { get; set; }
      [DataMember]
      public string ErrorMessage { get; set; }
    }
