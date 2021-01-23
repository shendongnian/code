    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var list = new List<ItemsInList>
                       {
                           new ItemsInList { Text = "Testtext1" },
                           new ItemsInList { Text = "Testtext2" },
                       };
            ListViewDesc.DataSource = list;
            ListViewDesc.DataBind();
        }
    }
    public class ItemsInList
    {
        public string Text { get; set; }
    }
            <asp:ListView ID="ListViewDesc" runat="server">
                <ItemTemplate>
                    <p>
                        <%# Eval("Text") %>
                    </p>
                </ItemTemplate>
            </asp:ListView>
