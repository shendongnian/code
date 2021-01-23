        public string DisplayDataRow(DataView dataView)
    {
        string rows = null;
        string lineBreak = "<br />";
        foreach(DataRowView rowView in dataView)
        {
            for(int index = 0; index < dataView.Table.Rows.Count; index++)
                rows += rowView.Row[index] + " ";
            rows+=lineBreak;
        }
        return rows;
    }
