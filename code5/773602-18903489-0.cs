    [DataContractAttribute]
    public class CommonFault
    {
        private string errorcode;
        private string errormessage;
        private string stackTrace;
        [DataMemberAttribute]
        public string ErrorCode
        {
            get { return this.code; }
            set { this.code = value; }
        }
        [DataMemberAttribute]
        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }
        [DataMemberAttribute]
        public string StackTrace
        {
            get { return this.stackTrace; }
            set { this.stackTrace = value; }
        }
        public CommonFault()
        {
        }
        public CommonFault(string code, string message, string stackTrace)
        {
            this.Code = code;
	        this.Message = message;
            this.StackTrace = stackTrace;
        }
    }
