    public partial class TableA
    {
        public static readonly TableB DefaultTableBValue = new TableB(null);
        public TableA()
        {
            this.First = TableA.DefaultTableBValue;
            this.Second = TableA.DefaultTableBValue;
            this.Third = TableA.DefaultTableBValue;
        }
    }
    public partial class TableB
    {
        public TableB(string value)
        {
            this.Value = value;
        }
    }
