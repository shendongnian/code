    Color[,] colourMapping = new Color[8,9];
    
     public Form1()
        {
          InitializeComponent();
         
          for (int i = 0; i < colourMapping.GetLength(0); i++)
          {
            for (int j = 0; j < colourMapping.GetLength(1); j++)
            {
              colourMapping[i,j] = Color.Beige;
            }
          }
    
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          if (e.RowIndex < colourMapping.GetLength(0) && e.ColumnIndex < colourMapping.GetLength(1))
          {
            e.CellStyle.BackColor = colourMapping[e.RowIndex, e.ColumnIndex];
          }
        }
