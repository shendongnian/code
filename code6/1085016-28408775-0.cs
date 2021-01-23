    public class Row: DependencyObject
    {
        //create a new row with the given value
        //automatically set Value, Info and RowType based on the param
        public Row(object val)
        {
            Value = val;
            if (val.GetType() == typeof(bool)) RowType = WpfApplication3.RowType.Bool;
            else RowType = WpfApplication3.RowType.Int32;
            Info = val.ToString() + " of type " +val.GetType().ToString();
        }
        public RowType RowType { get; set; }
        /// <summary>
        /// Gets or sets a bindable value that indicates Value
        /// </summary>
        public object Value
        {
            get { return (object)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(object), typeof(Row), new PropertyMetadata(0));
        /// <summary>
        /// Gets or sets a bindable value that indicates Info
        /// </summary>
        public string Info
        {
            get { return (string)GetValue(InfoProperty); }
            set { SetValue(InfoProperty, value); }
        }
        public static readonly DependencyProperty InfoProperty =
            DependencyProperty.Register("Info", typeof(string), typeof(Row), new PropertyMetadata(""));
    }
