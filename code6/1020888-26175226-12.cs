    public class RowBulder : IRowBulder
    {
        public IFirstColumnBuilder Column(...)
        {
             // do stuff
             return new ColumnBuilder(...);
        }
    }
