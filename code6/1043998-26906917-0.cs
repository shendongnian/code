    comboSMSMessages.Items.Clear(); Clear all the items 
    Add comboSMSMessages.Items.Add(new ComboboxItem() { Text = "(new)", Value = "-1" }); 
    after you cleared the combobox You code should be like
    string query = "SELECT Id,Name,Text FROM ApsisSms ORDER BY Id DESC";
    OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
    conn.Open();
    da.Fill(dtSmsMessages);
    if (dtSmsMessages.Rows != null && dtSmsMessages.Rows.Count > 0)
    {
    comboSMSMessages.Items.Clear();
    comboSMSMessages.Items.Add(new ComboboxItem() { Text = "(new)", Value = "-1" });
    for (int i = 0; i < dtSmsMessages.Rows.Count; i++)
    {
     ComboboxItem item = new ComboboxItem()
        {
            Text = dtSmsMessages.Rows[i]["Name"].ToString(),
            Value = dtSmsMessages.Rows[i]["Id"].ToString()
        };
        comboSMSMessages.Items.Add(item);
     }
    }
    comboSMSMessages.SelectedIndex = -1;
