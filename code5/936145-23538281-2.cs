      public static OperationResult WithError(this OperationResult operationResult, string errorCode,
                                              string error = null)
      {
        return operationResult.AddErrorImpl(errorCode, error);
      }
      public static OperationResult<T> WithError<T>(this OperationResult<T> operationResult, string errorCode,
                                                    string error = null)
      {
        return (OperationResult<T>) operationResult.AddErrorImpl(errorCode, error);
      }
      private static OperationResult AddErrorImpl(this OperationResult operationResult, string errorCode,
                                                  string error = null)
      {
        var operationError = new OperationError {Error = error ?? string.Empty, ErrorCode = errorCode};
        operationResult.Errors.Add(operationError);
        operationResult.Success = false;
        return operationResult;
      }
      public static OperationResult<T> WithResult<T>(this OperationResult<T> operationResult, T result)
      {
        operationResult.Result = result;
        return operationResult;
      }
