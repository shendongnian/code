    public interface ITransactionHistoryService
    {
        IEnumerable<TransactionHistory> GetByTransactionId(int transactionId);
        IEnumerable<TransactionHistory> GetByComment(string comment);
    }
    public sealed class TransactionHistoryService : ITransactionHistoryService
    {
        // Note SELECT * is frowned upon. Replace with actual column names.
        private const string GetByTransactionIdQuery =
            "SELECT * FROM dbo.TransactionHistory WHERE TransactionID = @TransactionId";
        private const string GetByCommentQuery =
            "SELECT * FROM dbo.TransactionHistory WHERE Comments = @Comment";
        private readonly IService _service;
        
        public TransactionHistoryService(IService service)
        {
            _service = service;
        }
        
        public IEnumerable<TransactionHistory> GetByTransactionId(int transactionId)
        {
            var result = _service.Execute(c =>
                                            c.Query<TransactionHistory>(GetByTransactionIdQuery,
                                                                        new { TransactionId = transactionId }));
            
            return result;
        }
        
        public IEnumerable<TransactionHistory> GetByComment(string comment)
        {
            var result = _service.Execute(c =>
                                            c.Query<TransactionHistory>(GetByCommentQuery,
                                                                        new { Comment = comment }));
            
            return result;
        }
    }
