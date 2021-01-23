    public class Customer
    {
        public Customer() { }
        public Customer(Customer cust)
        {
            ID = cust.ID;
            Name = cust.Name;
            FatherName = cust.FatherName;
            Email = cust.Email;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Email { get; set; }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        List<Customer> lstCustomer = new List<Customer>();
        if (Session["dt"] != null)
        {
          lstCustomer = (List<Customer>)Session["dt"];
        }
        Customer customer = new Customer();
        customer.ID = int.Parse(TextBox1.Text);
        customer.Name = TextBox2.Text;
        customer.FatherName = TextBox2.Text;
        customer.Email = TextBox2.Text;
        lstCustomer.Add(new Customer(customer));
        GridView1.DataSource = lstCustomer;
        GridView1.DataBind();
        Session["dt"] = lstCustomer;
    }
