    <asp:GridView ID="GridView1" runat="server"
        AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:DropDownList runat="server" ID="DropDownList9">
                        <asp:ListItem Text="Approve" Value="1" />
                        <asp:ListItem Text="Reject" Value="2" />
                        <asp:ListItem Text="Pending" selected="selected" Value="3">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof (int));
            table.Columns.Add("Name", typeof (string));
            table.Columns.Add("ApproveID", typeof(string));
                    
            table.Rows.Add(1, "Jon Doe", "1");
            table.Rows.Add(2, "Eric Newton", "2");
            table.Rows.Add(3, "Marry Doe", "3");
    
            GridView1.DataSource = table;
            GridView1.DataBind();
        }
    }
    
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var item = e.Row.DataItem as DataRowView;
    
            var dropDownList = e.Row.FindControl("DropDownList9") as DropDownList;
    
            // Get value from ApproveID column, 
            // and check whehter Approve, Reject or others.
            switch (item["ApproveID"].ToString())
            {
                case "1":
                case "2":
                    dropDownList.Enabled = false;
                    break;
                default:
                    dropDownList.Enabled = true;
                    break;
            }
        }
    }
