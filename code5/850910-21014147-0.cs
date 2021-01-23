    public class Transaction
    {
      private readonly double _amount;
      private readonly DateTime _date;
      public Transaction(double amount,DateTime date){
        _amount = amount;
        _date = date;
      }
      public double Amount {get{return _amount;}}
      public DateTime Date {get{return _date;}}
    }
