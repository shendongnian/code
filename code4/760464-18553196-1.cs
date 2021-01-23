    private void datagridview_MouseDown(Object sender, MouseEventArgs e)
    {
        DataGridView dgv = (DataGridView)sender;
        DataGridView.HitTestInfo click = dgv.HitTest(e.Location.X, e.Location.Y);
        //If your have predefined columns, then maybe better compare by Column.name
        if(click.RowIndex >= 0 && dgv.Columns(click.ColumnIndex) is DataGridViewImageColumn)
        {
            DataGridViewCell cellTmp = dgv.Row(click.RowIndex).Cells(click.ColumnIndex);
            if (cellTmp.Value == null)
            {
                cellTmp.Value = My.Resources.yourCheckedImage;
            }
            else
            {
                cellTmp.Value = null;
            }
        }
    }
