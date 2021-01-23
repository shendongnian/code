    public class ExtendedColumn : DataGridViewColumn
    {
        public ExtendedColumn()
            : base(new ExtendedCell())
        {
        }
    }
    public class ExtendedCell : DataGridViewCell
    {
        public ExtendedCell()
            : base()
        {
        }
        
        public override object DefaultNewRowValue
        {
            get
            {
                return "aaa";
            }
        }
    }
