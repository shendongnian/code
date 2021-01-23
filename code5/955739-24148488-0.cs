    protected void adsshow_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "like")
        {
            var lblAds = e.Item.FindControl("Labeladsid") as Label;
            var lbtn = e.Item.FindControl("Adstitlinkbtn") as LinkButton;
            var id = lblAds.Text;
            var title = lbtn.Text;
        }
    }
    <asp:ListView ID="adsshow" runat="server" DataSourceID="locationdatalistshow"
            style="text-align: left" onitemcommand="adsshow_ItemCommand" >
    <ItemTemplate>
...
        <asp:ImageButton ID="likebtn" runat="server" 
               ImageUrl="~/iconsimg/favoritestar2.png" CommandName="like" />
