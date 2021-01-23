    <asp:ListView ItemPlaceholderID="Test" runat="server" ID="ListView1" > 
                 
                <ItemTemplate> 
                    <div class ="btn-search">
                    <asp:Button ID="Button1" runat="server" Text='<%# Container.DataItem %>' CommandArgument='<%# Container.DataItem %>' /><br /> 
                    </div>
                </ItemTemplate> 
            </asp:ListView>  
            <asp:Literal runat="server" ID="Literal1"></asp:Literal> 
     
     protected void Page_Init(object sender, EventArgs e)
        {
            ListView1.ItemCommand += new EventHandler<ListViewCommandEventArgs>(ListView1_ItemCommand);
        }
        void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            Literal1.Text = "You clicked the " + (String)e.CommandArgument + " button";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var list = Enumerable.Range('A', 'Z' - 'A' + 1).Select(charCode => (char)charCode).ToList();
                ListView1.DataSource = list;
                ListView1.DataBind();
            }
        }
