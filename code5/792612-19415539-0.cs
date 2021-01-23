    <asp:DataGrid ID="DataGrid1" runat="server" 
        OnItemDataBound="DataGrid1_ItemDataBound" 
        AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateColumn HeaderText="Broker">
                <ItemTemplate>
                    <asp:Label ID="labelBrokerMPID" runat="server" /> - 
                    <asp:Label ID="labelBrokerName" runat="server" />
                </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
    </asp:DataGrid>
    
    public DataTable MyDataSource
    {
        get
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("BrokerMPID", typeof (Int32)));
            dt.Columns.Add(new DataColumn("BrokerName", typeof (string)));
    
            for (int i = 0; i < 5; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = "Name " + i;
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
            
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataGrid1.DataSource = MyDataSource;
            DataGrid1.DataBind();
        }
    }
    
    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var dr = e.Item.DataItem as DataRowView;
    
            var labelBrokerMPID = e.Item.FindControl("labelBrokerMPID") as Label;
            labelBrokerMPID.Text = dr["BrokerMPID"].ToString();
    
            var labelBrokerName = e.Item.FindControl("labelBrokerName") as Label;
            labelBrokerName.Text = dr["BrokerName"].ToString();
        }
    }
