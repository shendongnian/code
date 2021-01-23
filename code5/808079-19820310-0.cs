    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <telerik:RadGrid runat="server" 
        ID="commentRadGrid" 
        AllowFilteringByColumn="true" 
        AutoGenerateColumns="True"
        AllowPaging="true" 
        OnPageIndexChanged="commentRadGrid_PageIndexChanged" 
        OnNeedDataSource="commentRadGrid_NeedDataSource" 
        PageSize="100" Skin="Default" 
        AllowSorting="true" 
        ShowStatusBar="true" 
        AllowCustomPaging="True"
        GridLines="none">
    </telerik:RadGrid>
    <asp:Button runat="server" ID="OlderCommentsButton" 
        OnCommand="OlderCommentsButton_Click" Text="Post Back" />
    
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    protected void commentRadGrid_NeedDataSource(
        object sender, GridNeedDataSourceEventArgs e)
    {
        var users = new List<User>
        {
            new User {FirstName = "John", LastName = "Doe"},
            new User {FirstName = "Jenny", LastName = "Doe"},
        };
    
        commentRadGrid.DataSource = users;
        commentRadGrid.MasterTableView.VirtualItemCount = users.Count;
    }
    
    protected void OlderCommentsButton_Click(object sender, EventArgs e)
    {
        try
        {
            commentRadGrid.Rebind();
        }
        catch (Exception ex)
        {
        }
    }
    
    protected void commentRadGrid_PageIndexChanged(
        object sender, GridPageChangedEventArgs e)
    {
                
    }
