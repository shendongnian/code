    <asp:Button runat="server" ID="Button1" OnClick="Button1_Click" 
       Text="Load Page"/>
    <asp:PlaceHolder runat="server" ID="PlaceHolder1">
    </asp:PlaceHolder>
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        var uri = new Uri("http://www.stackoverflow.com");
        var result = new WebClient().DownloadString(uri);
        PlaceHolder1.Controls.Add(new LiteralControl(result));
    }
