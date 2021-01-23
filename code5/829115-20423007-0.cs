    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SetColor(this.dataGridView1.Columns[e.ColumnIndex].Name);
        }
    private void SetColor(string text)
    {
      switch(text)
     {
            case "DatePaid":
               e.CellStyle.ForeColor = Color.Blue;
            break;
            case "Something":
               e.CellStyle.ForeColor = Color.Red;
            break;
              
             
     }
}
