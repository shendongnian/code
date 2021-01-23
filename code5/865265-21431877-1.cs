    public class MyCell : DataGridViewCell
    {
      protected override object GetFormattedValue(object value, int rowIndex, ref System.Windows.Forms.DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter valueTypeConverter, System.ComponentModel.TypeConverter formattedValueTypeConverter, System.Windows.Forms.DataGridViewDataErrorContexts context)
      {
        return MyCustomFormatting(value);
      }
      private object MyCustomFormatting(object value)
      {
        return new SpecialFormatter.Format(value);
      }
    }
