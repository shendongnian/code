    protected void Page_Load(object sender, EventArgs e)
    {
        CartButton.Text = String.Format("View Cart {0}", Session["Counter"].ToString());
    }
    <asp:Button ID="CartButton" runat="server" OnClick="List_Items"  />
