    namespace Foo 
    {
    	public static class DataGridExtensions
    	{
    		public static void FormatViewCell(this DataGridViewCellFormattingEventArgs e)
    		{
    			var formatter = e.CellStyle.FormatProvider as ICustomFormatter;
    			if (formatter != null)
    			{
    				e.Value = formatter.Format(e.CellStyle.Format, 
    										   e.Value, 
    										   e.CellStyle.FormatProvider);
    				e.FormattingApplied = true;
    			}
    		}
    	}
    }
    
