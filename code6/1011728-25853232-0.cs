    class Transaction
    {
        public class Date
        {
            public int day, month, year;
        }
        Date d;
        double amount;
        long acc_no;
        string action;
        public Date GetDate()
        {
            return d; // Access Date d by using a method
        }
    }
       
