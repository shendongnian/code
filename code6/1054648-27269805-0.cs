    private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
    
            DataGridView dg = (DataGridView)sender;
            BindingSource bs = (BindingSource)dg.DataSource;
    
            //TODO;
           
        }
        else if (e.Button == MouseButtons.Right)
        {
    
                    
            FrmMyCalendar f = new FrmMyCalendar();
            f.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
    
            //TODO
    
                   
        }
    
    }
