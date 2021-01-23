    public interface IRecord
    {
        public DateTime TimeStamp {get;set;}
    }
    public enum TransactionType 
    {
        Debit , Credit
    }
    public class Transaction : IRecord
    {
        public DateTime TimeStamp {get;set;}
        public decimal Amount {get;set;}
        public TransactionType Type {get;set;}
        public Account TargetAccount {get;set;} 
    }
    public class Atm 
    {
        private List<Tuple<Acount,Transaction>> _record = new List<Tuple<Account,Transaction>>();
        private ICashHandler _cashHandler;
        public Atm(ICashHandler handler)
        {
            _cashHandler = handler;
        }
        public void Withdraw(Account account, decimal amount)
        {
            _record.Add(Tuple.Create(account, 
                new Transaction {
                    TimeStamp = DateTime.Now,
                    Amount = amount,
                    Type = TransactionType.Debit,
                    TargetAccount = account
                })
            );
            _cashHandler.Dispense(amount);
        }
        public void Deposit(Account account)
        {
            decimal amount;
            if( _cashHandler.TakeDeposit( out amount ) ) 
            {
                _record.Add(Tuple.Create(account, 
                    new Transaction {
                        TimeStamp = DateTime.Now,
                        Amount = amount,
                        Type = TransactionType.Credit,
                        TargetAccount = account
                    })
                );
            }
        }
    }
