    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </div>
    </form>
    public partial class Step1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {  }
    
        protected void Button1_Click(object sender, EventArgs e)
        {
            var n = Convert.ToInt32(TextBox1.Text);
            Session["temp"] = n * n;
            Response.Redirect("Step2.aspx");
        }
    }
