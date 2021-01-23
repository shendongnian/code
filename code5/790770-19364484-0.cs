    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Other { get; set; }
    }
    
    
    // Page1.aspx.cs
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        var customer = new Customer
        {
            FirstName = FirstNameTexBox.Text,
            LastName = LastNameTexBox.Text
        };
        Session["Customer"] = customer;
        
        // Redirect to page 2
        Response.Redirect("Page2.aspx");
    }
    
    // Page2.aspx.cs
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        var customer = Session["Customer"] as Customer;
        customer.Address = AddressTextBox.Text;
        Session["Customer"] = customer;
    
        // Redirect to page 3
        Response.Redirect("Page3.aspx");
    }
    
    // Page9.aspx.cs
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        var customer = Session["Customer"] as Customer;
        customer.Other = OtherTextBox.Text;
            
        // Save customer to database.
    }
