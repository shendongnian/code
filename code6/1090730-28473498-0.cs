    <form id="form1" runat="server">
       <asp:Button ID="city" runat="server" Text="London" value="London" OnClick="Button_Click" />  
       <asp:Button ID="city" runat="server" Text="Paris" value="Paris" OnClick="Button_Click" />  
       <asp:Button ID="city" runat="server" Text="Madrid" value="Madrid" OnClick="Button_Click" />  
    </form>
    protected void Button_Click(object sender, EventArgs e)
    {
        String city= Request.QueryString["city"];
        SqlConnection sqlCon = new SqlConnection("xx");
        sqlCon.Open();
        SqlCommand sqlCmd = new SqlCommand("Select * from Table where City = city", sqlCon)
    }
