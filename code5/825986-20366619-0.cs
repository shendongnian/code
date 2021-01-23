    private void gridProject_FormattingRow(object sender, RowLoadEventArgs e)
    {
        string s = e.Row.Cells["Status"].Value.ToString();
        if (s == "True")
        {
            if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record)
            {
                Janus.Windows.GridEX.GridEXFormatStyle rowcol = new GridEXFormatStyle();
                rowcol.BackColor = Color.LightGreen;
                e.Row.RowStyle = rowcol;
            }
                
            e.Row.Cells["Status"].Text = "yes";
         }
         else
         {
              e.Row.Cells["Status"].Text = "no";
         }
    }
