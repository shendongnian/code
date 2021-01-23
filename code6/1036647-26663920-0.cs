    private void scanner()
    {
        //...code for parser that assembles a List<> ...
        for(int x = 0; x < ChannelRS422List.Count; x++)
        {
            RowDataBuffer[0] = ChannelRS422List.channel;
            dgv.Rows.Add(RowDataBuffer);
        }
 
        int rowCount = 0;
        for (int row = 0; row < dgv.Rows.Count; row++)
        {
            DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)(dgv.Rows[row].Cells[1]);
            cell.DataSource = Populate("SELECT Channel_Type FROM Table1 WHERE Interface='RS422'");
            cell.ValueMember = "Channel_Type";
            cell.DisplayMember = cell.ValueMember;
            rowCount = row+1;
        }
        for(int x = 0; x < ChannelRS232List.Count; x++)
        {
            RowDataBuffer[0] = ChannelRS232List.channel;
            dgv.Rows.Add(RowDataBuffer);
        }
        for (int row = rowCount; row < dgv.Rows.Count; row++)
        {
            DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)(dgv.Rows[row].Cells[1]);
            cell.DataSource = Populate("SELECT Channel_Type FROM Table1 WHERE Interface='RS232'");
            cell.ValueMember = "Channel_Type";
            cell.DisplayMember = cell.ValueMember;
            rowCount = row+1;
        }
    }
    
