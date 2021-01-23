    public class Client
    {
        public virtual int ID { get; set; }
        public virtual IList<Agreement> Agreements { get; set; }
        ...
    }
    public class Agreement
    {
        public virtual int ID { get; set; }
        public virtual Client Client { get; set; }
        public virtual IList<Debtor> Debtors { get; set; }
        ...
    }
    public class Debtor
    {
        public virtual int ID { get; set; }
        public virtual IList<Agreement> Agreements { get; set; }
        ...
    }
