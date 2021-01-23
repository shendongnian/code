    <asp:Repeater ID="ParentRepeater" runat="server"    
       OnItemDataBound="ParentRepeater_ItemDataBound">
        <ItemTemplate>
            <strong>Parent</strong>
            <asp:Label runat="server" ID="FirstNameLabel" 
            Text='<%# Eval("FirstName") %>' />
            <asp:Label runat="server" ID="LastNameLabel" 
            Text='<%# Eval("LastName") %>' />
            <br/>
            <!-- Repeated data -->
            <asp:Repeater ID="ChildRepeater" runat="server">
                <ItemTemplate>
                    <!-- Nested repeated data -->
                    <strong>Children</strong>
                    <asp:Label runat="server" ID="FirstNameLabel" 
                    Text='<%# Eval("FirstName") %>' />
                    <asp:Label runat="server" ID="LastNameLabel" 
                    Text='<%# Eval("LastName") %>' /><br/>
                </ItemTemplate>
            </asp:Repeater>
            <hr/>
        </ItemTemplate>
    </asp:Repeater>
    
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public List<User> Children;
    
        public User()
        {
            Children = new List<User>();
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var users = new List<User>
            {
                new User
                {
                    UserId = 1,
                    FirstName = "Jon",
                    LastName = "Doe",
                    Children = new List<User> {new User {
                      UserId = 3, FirstName = "Marry", LastName = "Doe"}}
                },
                new User
                {
                    UserId = 2,
                    FirstName = "Eric",
                    LastName = "Newton",
                    Children = new List<User> {new User {
                      UserId = 3, FirstName = "Nick", LastName = "Newton"}}
                }
            };
    
            ParentRepeater.DataSource = users;
            ParentRepeater.DataBind();
        }
    }
    
    protected void ParentRepeater_ItemDataBound(object sender, 
        RepeaterItemEventArgs args)
    {
        if (args.Item.ItemType == ListItemType.Item || 
           args.Item.ItemType == ListItemType.AlternatingItem)
        {
            var user = args.Item.DataItem as User;
            var childRepeater = (Repeater) args.Item.FindControl("ChildRepeater");
    
            // You can get parent id like this - 
            // int parentUserId = user.UserId;
            childRepeater.DataSource = user.Children;
            childRepeater.DataBind();
        }
    }
