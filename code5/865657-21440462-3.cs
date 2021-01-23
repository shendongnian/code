    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ListView ID="ListViewPersons" runat="server" ItemPlaceholderID="ProductItem">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="LabelEmail" Text='<%# Eval("Email") %>'></asp:Label>
                        <asp:Label runat="server" ID="LabelName" Text='<%# Eval("Name") %>'></asp:Label>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <asp:PlaceHolder runat="server" ID="ProductItem"></asp:PlaceHolder>
                    </LayoutTemplate>
                    <ItemSeparatorTemplate>
                        <hr />
                    </ItemSeparatorTemplate>
                </asp:ListView>
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListViewPersons" 
                    onprerender="DataPager1_PreRender">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                    </Fields>
                </asp:DataPager>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ListViewPersons" />
            </Triggers>
        </asp:UpdatePanel>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindListView();                
            }
        }
        private void BindListView()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 30; i++)
            {
                Person aPerson =new Person();
                aPerson.Email = "Email" + i.ToString();
                aPerson.Name = "Name" + i.ToString();
                persons.Add(aPerson);
            }
            ListViewPersons.DataSource = persons;
            ListViewPersons.DataBind();
        }        
        public class Person
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }
        protected void DataPager1_PreRender(object sender, EventArgs e)
        {
            BindListView();
        }
