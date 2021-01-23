    private const string dir = @"Z:\Desktop\Windows 7 Files\C#.net\CustomerList\CustomerList";
    private const string path = Path.Combine(dir, "CustomerDat.txt");
    List<Customer> custList = new List<Customer>(); // this create the list to add the Customers to.
    while (textIn.Peek() != -1)
    {
       string row = textIn.ReadLine();
       string[] columns = row.Split(',');
       Customer customer = new Customer();
       customer.Name = columns[0];
       customer.Email = columns[1];
       customer.CreditRating = Convert.ToInt16(columns[2]);
       customer.City = columns[3];
       customer.Zip = columns[4];
       custList.Add(customer); //This was missing
    }
