        <FooterTemplate>
            <asp:DropDownList ID="ddlStatusList" runat="server">
            </asp:DropDownList>
            <input id="txtNotes" type="text" placeholder="Notes" runat="server" />
            <asp:Button runat="server" type="button" Text="Add" ID="btnAdd" OnClick="btnAdd_Click"></asp:Button>
        </FooterTemplate>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Button btnAdd = (Button)sender;
            DropDownList ddlStatusList = (DropDownList)btnAdd.NamingContainer.FindControl("ddlStatusList");
            System.Web.UI.HtmlControls.HtmlInputText txtNotes = (System.Web.UI.HtmlControls.HtmlInputText)btnAdd.NamingContainer.FindControl("txtNotes");
            int index = ddlStatusList.SelectedIndex;
            string text = txtNotes.Value;
        }
