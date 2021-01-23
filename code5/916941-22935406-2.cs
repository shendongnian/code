    public void UpdateColorControls(Control myControl)
    {
       if (myControl is TextBox)
       {
           myControl.BackColor = Colors.Black;
           myControl.ForeColor = Colors.White;
       }
       if (myControl is DataGridView)
       {
          DataGridView MyDgv = (DataGridView)myControl;
          MyDgv.ColumnHeadersDefaultCellStyle.BackColor = Colors.Black;
          MyDgv.ColumnHeadersDefaultCellStyle.ForeColor = Colors.White;
       }
       foreach (Control subC in myControl.Controls) 
       {
           UpdateColorControls(subC);
       } 
    }
