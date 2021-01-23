foreach (DataRow drRow in DS_LASSummary.Rows)
    {
        for(int i = 0; i < DS_LASSummary.Columns.Count; i++)
        {
            int rowValue;
            if (int.TryParse(drRow[i].ToString(), out rowValue))
            {
                
				drRow[i] = Math.Round(rowValue, 2);
            }
        }
    }
</pre>
