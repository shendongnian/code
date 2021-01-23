    public List<wsCustomer> GetAllCustomers()
                {
                    NorthwindDataContext dc = new NorthwindDataContext();
                    List<wsCustomer> results = new List<wsCustomer>();
    
                    foreach (Customer cust in dc.Customers)
                    {
                        results.Add(new wsCustomer() {
                            CustomerID = cust.CustomerID,
                            CompanyName = cust.CompanyName,
                            City = cust.City
                        });
                    }
                    Map<String,List<wsCustomer>> resultMap = new HashMap<String,List<wsCustomer>>();
                    resultMap.put("result",results);
                    return resultMap;
                }
