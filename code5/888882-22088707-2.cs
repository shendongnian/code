    <form id="form1" runat="server">
        <div>
            Result is <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
    
    public partial class Step3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var res = (Session["result"] as int?);
            Label1.Text = res.ToString();
        }
    }
