    DataTable table = (DataTable)dataGridView.DataSource;
    for (int r = 0; r < table.Columns.Count; r++)
    {
       DataRow row = table.Rows[r];
       for (int c = 0; c < table.Columns.Count; c++)
       {
         string s = "";
         if (row[c] != null) s = row[c].ToString();
         e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, 
                       12.0F, FontStyle.Bold), Brushes.Black,  new Point(c * 123, r * 12));
       }
    }
