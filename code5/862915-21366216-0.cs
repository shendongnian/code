    interface IFinancialOperationVisitor<T, out R> : IMonadicActionVisitor<T, R> {
        R GetTransactions(GetTransactions op);
        R PostTransaction(PostTransaction op);
    }
    interface IFinancialOperation<T> {
        R Accept<R>(IFinancialOperationVisitor<T, R> visitor);
    }
    class GetTransactions : IFinancialOperation<IError<IEnumerable<Transaction>>> {
        Account Account {get; set;};
        public R Accept<R>(IFinancialOperationVisitor<R> visitor) {
            return visitor.Accept(this);
        }
    }
    class PostTransaction : IFinancialOperation<IError<Unit>> {
        Transaction Transaction {get; set;};
        public R Accept<R>(IFinancialOperationVisitor<R> visitor) {
            return visitor.Accept(this);
        }
    }
    
