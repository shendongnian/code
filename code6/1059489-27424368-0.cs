    private static void AddCellFormatting(DataGridView dgView)
    {
	    dgView.CellFormatting += (sender, e) => 
	    {
		    var formatter = e.CellStyle.FormatProvider as ICustomFormatter;
            if (formatter != null)
		    {
			    e.Value = formatter.Format(e.CellStyle.Format, e.Value, e.CellStyle.FormatProvider);
			    e.FormattingApplied = true;
		    }
	    }
    }
