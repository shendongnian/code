    [SqlUserDefinedAggregate(Format.UserDefined,
            //Play it safe, we don't know how large we'll get
            MaxByteSize = -1,
            Name = "FinancialCalc", IsInvariantToDuplicates = false,
            IsInvariantToNulls = true, IsInvariantToOrder = true,
            IsNullIfEmpty = true)]
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public class FinancialCalc : IBinarySerialize
    {    
        private List<Transaction> transactions;
    
        public void Init()
        {        
            this.transactions = new List<Transaction>();
        }
    
        public void Accumulate(SqlDouble amount, SqlDateTime date)
        {
            this.transactions.Add(new Transaction(date.Value,amount.Value));
        }
    
        public void Merge(FinancialCalc Group)
        {
           //Yes, you do need this. Group contains another set of transactions
           //and is going to disappear after this method has been called
           this.transactions.AddRange(Group.transactions);
        }
    
        public SqlDouble Terminate()
        {
            //Do your calculation based on the content of transactions
            return new SqlDouble(transactions.Sum(t=>t.Amount));
        }
    
        public void Read(System.IO.BinaryReader r)
        {
            int itemCount = r.ReadInt16();
    
            for (int i = 0; i <= itemCount - 1; i++)
            {
                this.transactions.Add(new Transaction(r.ReadDouble(),
                                           new DateTime(r.ReadInt64()));          
            }
        }
    
        public void Write(System.IO.BinaryWriter w)
        {
            w.Write(this.transactions.Count);
            foreach (var t in this.transactions)
            {
                w.Write(t.Amount);
                w.Write(t.Date.ToBinary());
            }
        }
    }
