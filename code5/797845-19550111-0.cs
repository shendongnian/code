    <asp:GridView ID="GridView1" runat="server"
        AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:DropDownList runat="server" ID="DropDownList9">
                        <asp:ListItem Text="Approve" Value="Approve" />
                        <asp:ListItem Text="Reject " Value="Reject" />
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
            table.Columns.Add("Status", typeof(string));
                    
            table.Rows.Add(1, "Jon Doe", "Approve");
            table.Rows.Add(2, "Eric Newton", "Reject");
            table.Rows.Add(3, "Marry Doe", "");
    
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
    
            // Get value from Status column, 
            // and check whehter Approve, Reject or others.
            switch (item["Status"].ToString())
            {
                case "Approve":
                case "Reject":
                    dropDownList.Enabled = false;
                    break;
                default:
                    dropDownList.Enabled = true;
                    break;
            }
        }
    }
