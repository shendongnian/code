    private void BindClientCombobox(DataTable clientDataTable)
    {
        this.cbClients.DataSource = clientDataTable;
        this.cbClients.ValueMember = "client_id";
        this.cbClients.DisplayMember = "client_name";
    }
        
    private bool ContainsClientID(int clientID)
    {
        return this.cbClients.Items.Cast<DataRowView>().Any(drv => (int)drv.Row.ItemArray[0] == clientID);
    }
    private bool ContainsClientName(string clientName)
    {
        return this.cbClients.Items.Cast<DataRowView>().Any(drv => (string)drv.Row.ItemArray[1] == clientName);
    }
