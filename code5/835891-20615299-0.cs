     protected void btnClick_Click(object sender, EventArgs e)
       {
        lblString.Text = ViewState["PageState"].ToString();
        lblString.Visible = true;
           
       }
    
       private void Close(object sender, EventArgs e)
       {
           lblString.Visible = !lblString.Visible;
           lblString.Visible = false;
       }
    
    ViewState Data: <b><asp:Label ID="lblString" runat="server"/></b>
    <asp:Button ID="btnClick" runat="server" Text="Get ViewState Data" OnClick="btnClick_Click"/>
    <asp:Button ID="Closeform" runat="server" Text ="Hide PageState" OnClick="Close" />
