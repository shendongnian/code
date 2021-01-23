    private void radGridView1_RowValidating(object sender, RowValidatingEventArgs e)
    {
        var row = e.Row as GridViewDataRowInfo;        
            var value = row.Cells["cboUnit"].Value.ToString();
            if (string.IsNullOrEmpty(value) && row != null)
            {
                e.Cancel = true;
                row.ErrorText = "Unit Number is a required field";
            }
            else
            {
                row.ErrorText = string.Empty;
            }
