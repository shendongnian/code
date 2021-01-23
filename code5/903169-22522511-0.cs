    public partial class Administration_CustomerDisplay : System.Web.UI.Page
    {
        Customer customer;
    
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            customer = new Customer();
            customer.Name = "test";
            Session("customer") = customer
        }
    
        protected void Button1_Click(object sender, EventArgs e)
        {
            customer = Session("customer")
            Console.WriteLine(customer.Name);   //Why is this null ?
        }
    }
