        internal static class DataGridViewExtensions
        {
        	public static void CloneRowWithValues(this DataGridViewRow SingleRow, DataGridView Target)
        	{
        		DataGridViewRow Results = (DataGridViewRow)SingleRow.Clone();
        		for (Int32 Row = 0; Row < SingleRow.Cells.Count; Row++)
        		{
        			Results.Cells[Row].Value = SingleRow.Cells[Row].Value;
        		}
        		Target.Rows.Add(Results);
        	}
        }
