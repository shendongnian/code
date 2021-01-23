    protected void Grid_RowDataBound(Object sender, GridViewRowEventArgs e) {
        string someVariable1 = Convert.ToString((Grid.Rows[0].Cells["comboCell"] as DataGridViewComboBoxCell).FormattedValue.ToString());
        if(e.Row.RowType == DataControlRowType.DataRow) {
             if(someVariable1 == "Done")
                 e.Row.BackColor = Color.Green;
        }
    }
