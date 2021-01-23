    public class ExtendedColumn : DataGridViewColumn
    {
        public ExtendedColumn()
            : base(new ExtendedCell())
        {
        }
    }
    public class ExtendedCell : DataGridViewTextBoxCell
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
