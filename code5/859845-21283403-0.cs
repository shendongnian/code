    [DataContract(Namespace = "SharedServices")]
    public class Error<T>
    {
        /// <summary>
        /// Gets or Sets Error Code
        /// </summary>
        [DataMember]
        public int ErrorCode { get; set; }
        /// <summary>
        /// Gets or Sets detailed error message
        /// </summary>
        [DataMember]
        public string ErrorMessage { get; set; }
        public Error()
        {
            ErrorMessage = NullValues.NullString;
            ErrorCode = NullValues.NullInt;
        }
        public Error(T errorType, string errorMessage)
        {
            ErrorCode = Convert.ToInt32(errorType);
            ErrorMessage = errorMessage;
        }
    }
