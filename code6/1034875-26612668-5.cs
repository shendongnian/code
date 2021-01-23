    namespace Interfaces
    {
        public interface IDataItem
        {
            CustomerInfo customer { get; set; }
            LoanInfo loan { get; set; }
            DateTime loanProcessingDate { get; set; }
            string moduleID { get; set; }
            string processingState { get; set; }
        }
    }
