    List<Customer> customers;
    public Form1()
    {
         InitializeComponent();
         
         //you could add the Customers directly to the add method of the list.
         Customer c1 = new Customer("Sibel Yilmaz", "Wollongong", 2500, 3000, 5000);
         Customer c2 = new Customer("John Doe", "Figtree", 2547, 2500, 3655);
         Customer c3 = new Customer("Mariah Moore", "Coniston", 2500, 7000, 36000);
         Customer c4 = new Customer("Jessica Blackshaw", "Bellambi", 3500, 6000, 4750);
         Customer c5 = new Customer("Suzan Yilmaz", "Wollongong", 2500, 2000, 47110);
    
         customers = new List<Customer>();
    
         customers.Add(c1);
         customers.Add(c2);
         customers.Add(c3);
         customers.Add(c4);
         customers.Add(c5);
    
         textBox1.DataBindings.Add("Text", customers, "Name",true,DataSourceUpdateMode.OnPropertyChanged);
         textBox2.DataBindings.Add("Text", customers, "Suburb", true, DataSourceUpdateMode.OnPropertyChanged);
         textBox3.DataBindings.Add("Text", customers, "Postcode", true, DataSourceUpdateMode.OnPropertyChanged);
         textBox4.DataBindings.Add("Text", customers, "Credit_Balance", true, DataSourceUpdateMode.OnPropertyChanged);
         textBox5.DataBindings.Add("Text", customers, "Savinig_Balance", true, DataSourceUpdateMode.OnPropertyChanged);
    }
