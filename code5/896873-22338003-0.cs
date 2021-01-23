    <asp:Label runat="server" ID="Label1" />
    <asp:Button ID="PostBackButton" OnClick="PostBackButton_Click" 
        runat="server" Text="Post Back" />
    
    public class Customer
    {
        public int Id { get; set; }
    }
    
    public Customer SessionCustomer
    {
        get
        {
            var customer = Session["Customer"] as Customer;
            return customer ?? new Customer();
        }
        set { Session["Customer"] = value; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            SessionCustomer = new Customer() {Id = 1};
        }
    }
    
    protected void PostBackButton_Click(object sender, EventArgs e)
    {
        // Display the Customer ID 
        Label1.Text = SessionCustomer.Id.ToString();
    }
