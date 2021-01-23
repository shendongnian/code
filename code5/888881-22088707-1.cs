    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> 
            * 
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> 
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </div>
    </form>
    
    public partial class Step2 : System.Web.UI.Page
    {
        private int? firstValue;
        protected void Page_Load(object sender, EventArgs e)
        {
            firstValue = (Session["temp"] as int?);
            Label1.Text = firstValue.ToString();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            var multiplicator = Convert.ToInt32(TextBox1.Text);
            var result = firstValue*multiplicator;
            Session["result"] = result;
            Response.Redirect("Step3.aspx");
        }
    }
