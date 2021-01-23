    public class ExtendedColumn : DataGridViewColumn
    {
        public ExtendedColumn()
            : base(new ExtendedCell())
        {
        }
        public ExtendedColumn(string val)
            : base(new ExtendedCell(val))
        {
        }
    }
    public class ExtendedCell : DataGridViewTextBoxCell
    {
        static string defaultValue = string.Empty;
        public ExtendedCell()
            : base()
        {
        }
        public ExtendedCell(string value)
            : base()
        {
            defaultValue = value;
        }
        public override object DefaultNewRowValue
        {
            get
            {
                return defaultValue;
            }
        }
    }
