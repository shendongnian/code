    DateTimePicker dtp = new DateTimePicker();  //DateTimePicker
    Rectangle _Rectangle;
    private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dataGridView2.Columns[e.ColumnIndex].Name)
            {
                case "dateAchatDataGridViewTextBoxColumn1":
                    _Rectangle = dataGridView2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //  
                    dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height); //  
                    dtp.Location = new Point(_Rectangle.X, _Rectangle.Y); //  
                    dtp.Visible = true;  
                    break;
            }
        }
        private void dtp_TextChange(object sender, EventArgs e)
        {
            dataGridView2.CurrentCell.Value = dtp.Text.ToString();  
        }  
        
        private void dataGridView2_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)  
        {  
            dtp.Visible = false;  
              
        }  
  
     
        private void dataGridView2_Scroll(object sender, ScrollEventArgs e)  
        {  
            dtp.Visible = false;  
        }
