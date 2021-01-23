        protected void Page_Load(object sender, EventArgs e)
        {
            string test = "s1,s2,s3";
            string[] StrArray = test.Split(',');
            if (!Page.IsPostBack)
            {
                rptTest.DataSource = StrArray;
                rptTest.DataBind();
            }
        }
        <asp:Repeater runat="server" ID="rptTest"> 
            <ItemTemplate>
             <%# Container.DataItem %>
            </ItemTemplate>
        </asp:Repeater>
