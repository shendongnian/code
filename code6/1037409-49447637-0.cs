    Try This Code working Fine.
    -- C# Code here---
    <form id="form1" runat="server">
        <div>
        <h1>Gridview Property of Sorting</h1>
          <br />
            <asp:GridView ID="gdviewevent" runat="server" AutoGenerateColumns="false" OnSorting="gdviewevent_Sorting" AllowSorting="true">
                 <HeaderStyle BackColor="YellowGreen" Font-Bold="True" Font-Names="cambria" ForeColor="Black" />
    
                <RowStyle Font-Names="Calibri" />
                <Columns>
                    <asp:TemplateField HeaderText="Sr No.">
                        <ItemTemplate>
                            <span><%#Container.DataItemIndex+1 %></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="India Value" SortExpression="IndiaVal">
                        <ItemTemplate>
                            <asp:Label ID="lblindiavalue" runat="server" Text='<%#Eval("Column1") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Created Date" SortExpression="Registereddate">
                        <ItemTemplate>
                            <asp:Label id="lblcreateddate" runat="server" Text='<%#Eval("Registereddate", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        </form>
    
    -- Page behind Code ---
     protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    FillGridView();
                }
            }
            protected void FillGridView()
            {
                string query = "Select Column1, Registereddate from tablename";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    gdviewevent.DataSource = dt;
                    gdviewevent.DataBind();
                    ViewState["dirState"] = dt;
                    ViewState["sortdr"] = "Asc";
                }
            }
    
            protected void gdviewevent_Sorting(object sender, GridViewSortEventArgs e)
            {
                DataTable dtrslt = (DataTable)ViewState["dirState"];
                if (dtrslt.Rows.Count > 0)
                {
                    if (Convert.ToString(ViewState["sortdr"]) == "Asc")
                    {
                        dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                        ViewState["sortdr"] = "Desc";
                    }
                    else
                    {
                        dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                        ViewState["sortdr"] = "Asc";
                    }
                    gdviewevent.DataSource = dtrslt;
                    gdviewevent.DataBind();
                }
    
            }
