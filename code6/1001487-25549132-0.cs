    public class Test
    {
    	public string daysleft { get; set; }
    }
    
    public partial class _Default : System.Web.UI.Page
    {
    	protected void Page_Load(object sender, EventArgs e)
    	{
    		if (!IsPostBack)
    		{
    			var items = new List<Test>
    			{
    				new Test {daysleft = "Deepu"},
    				new Test {daysleft = "Darsh"}
    			};
    			rpt_users.DataSource = items;
    			rpt_users.DataBind();
    		}
    	}
    
    	protected void Unnamed_TextChanged(object sender, EventArgs e)
    	{
    		var repeaterItem = (sender as TextBox).NamingContainer as RepeaterItem;
    		var hiddenFieldKey = repeaterItem.FindControl("LoginField") as HiddenField;
    	}
    }
    <asp:Repeater ID="rpt_users" runat="server">
    <ItemTemplate>
    <asp:TextBox ID="TextBox1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "daysleft") %>' OnTextChanged="Unnamed_TextChanged" AutoPostBack="true"/><br />
    </ItemTemplate>
    </asp:Repeater>
   
