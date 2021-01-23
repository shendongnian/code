    DateTimePicker dtPicker;
    
    private void Form_Load(object sender, EventArgs e)
    {
        dtPicker = new DateTimePicker();
        dtPicker.Format = DateTimePickerFormat.Short;
        dtPicker.Visible = false;
        dtPicker.Width = 100;
        dgT.Controls.Add(dtPicker);
        dtPicker.ValueChanged += this.dtPicker_ValueChanged;
        dgT.CellBeginEdit += this.dgT_CellBeginEdit;
        dgT.CellEndEdit += this.dgT_CellEndEdit;
    }
    
    private void dgT_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
        try
        {
            if ((dgT.Focused) && (dgT.CurrentCell.ColumnIndex == 2))   // Here you can define on which column DateTimePicker will be activated
            {
                dtPicker.Location = dgT.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                dtPicker.Visible = true;
    
                if (dgT.CurrentCell.Value != DBNull.Value)
                {
                    dtPicker.Value = (DateTime)dgT.CurrentCell.Value;
                }
                else
                {
                    dtPicker.Value = DateTime.Today;
                }
            }
            else
            {
                dtPicker.Visible = false;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
    
    private void dgT_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            if ((dgT.Focused) && (dgT.CurrentCell.ColumnIndex == 2))
            {
                dgT.CurrentCell.Value = dtPicker.Value.Date;                       
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
    
    private void dtPicker_ValueChanged(object sender, EventArgs e)
    {
        dgT.CurrentCell.Value = dtPicker.Text;
    }
    
    private void dgT_Scroll(object sender, ScrollEventArgs e)
    {
        dtPicker.Visible = false;
    }
