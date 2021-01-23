        public class ApiException : Exception
        {
            public int FaultCode { get; private set; }
    
            public ApiException(int faultCode, string message)
                : base(message)
            {
                this.FaultCode = faultCode;
            }
        }
