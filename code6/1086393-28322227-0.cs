    public JOVALException(ErrorCodes _errCode, String _message = "",
      Exception innerException = null) : base(_message, innerException)
    {
      ErrMessage = _message;
      ErrCode = _errCode;
    }
