    private void btnClone_Click(object sender, EventArgs e)
    {
         List<Customer> abc = new List<Customer>();
         customers = new List<Customer>();
         for (int i = 0; i < 5; i++)
         {
              Customer cust = (Customer)customer.Clone();
              customers.Add(cust);
              abc.Add(cust);
         }
    }
