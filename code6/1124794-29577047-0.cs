    private void Form4_Load(object sender, EventArgs e)
    {
        SelectClientcomboBox.DataSource = AgencyContext.Client.ToList();
        SelectClientcomboBox.DisplayMember = "ClientName";
        SelectClientcomboBox.ValueMember = "ClientID";
        SelectClientcomboBox.Invalidate();
    }
