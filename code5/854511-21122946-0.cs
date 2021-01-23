    <asp:UpdatePanel ID="upInvoice" runat="server">
            <ContentTemplate>
                <div id="divSearch" style="background-color: #e6f3e7; border: 1px solid #333; min-height: 50px;">
                    <asp:Panel ID="pnlSearch" runat="server" DefaultButton="BtnGo">
                        <br />
                        <asp:Label ID="lblClient" runat="server" Text="Client:" CssClass="head2" ClientIDMode="Static"></asp:Label>&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlClient" runat="server" Width="200px" CssClass="norm" ClientIDMode="Static"
                            AutoPostBack="true" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                        </asp:DropDownList>
                        &nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="Area:" ClientIDMode="Static"
                            CssClass="head2" Visible="false"></asp:Label>&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlArea" runat="server" Width="200px" ClientIDMode="Static"
                            CssClass="norm" Visible="false">
                        </asp:DropDownList>
                       <asp:Button ID="btnGo" runat="server"
                                    CssClass="btn" Text="Go" OnClick="btnGo_Click" />
                        </br> </br>
                    </asp:Panel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
     protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
    
                    BindInvoicingClients();
    
                    ddlArea.Items.Add(new ListItem("[ALL]", "0"));
                    ddlArea.SelectedValue = "0";
    
                }
            }
            protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (int.Parse(ddlClient.SelectedValue) == 1)
                {
                    PopulatePropertyAreaDropdown(int.Parse(ddlClient.SelectedValue));
                   
                }
            }
    
     protected void btnGo_Click(object sender, EventArgs e)
            {
    
                grdInvoice.DataSource = null;
                grdInvoice.DataBind();
    
                BindGrid(int.Parse(ddlClient.SelectedValue));
    
            }
