    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Customer> lstCustomer = new List<Customer>();
            Customer customer = new Customer();
            customer.ID = 1;
            customer.Name = "John Cena";
            customer.FatherName = "John";
            customer.Email = "cena@gmail.com";
            lstCustomer.Add(new Customer(customer));
            customer.ID = 2;
            customer.Name = "Mokesh";
            customer.FatherName = "Rajnikant";
            customer.Email = "mokesh@gmail.com";
            lstCustomer.Add(new Customer(customer));
            customer.ID = 3;
            customer.Name = "Bilal Ahmad";
            customer.FatherName = "Kashif";
            customer.Email = "bilal@gmail.com";
            lstCustomer.Add(new Customer(customer));
            customer.ID = 4;
            customer.Name = "Chin Shang";
            customer.FatherName = "Shang Woe";
            customer.Email = "chinshang@gmail.com";
            lstCustomer.Add(new Customer(customer));
            Session["dt"] = lstCustomer;
        }
    }
