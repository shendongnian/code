    class WMZDGVDateCell : DataGridViewTextBoxCell
    {
        protected override bool SetValue(int rowIndex, object value)
        {
            if (value != null) System.Diagnostics.Debug.WriteLine("------in SetValue-------" + value.ToString());
    
            DateTime valueAsDate;
            if (value != null && DateTime.TryParse(value.ToString(), out valueAsDate))
            {
                //succeeded
            }
            else
            {
                valueAsDate = new DateTime(2222, 2, 22);
                //failed
            }
    
            return base.SetValue(rowIndex, valueAsDate.ToShortDateString());
        }
    
    
        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter valueTypeConverter, System.ComponentModel.TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value != null) System.Diagnostics.Debug.WriteLine("------in GetFormattedValue-------" + value.ToString());
    
            DateTime valueAsFormatted;
            if (value != null && DateTime.TryParse(value.ToString(), out valueAsFormatted))
            {
                //succeeded
            }
            else
            {
                valueAsFormatted = new DateTime(2222, 2, 22);
                //failed
            }
    
            return base.GetFormattedValue(valueAsFormatted.ToShortDateString(), rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }
    }
