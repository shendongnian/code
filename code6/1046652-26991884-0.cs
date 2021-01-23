    var customers = from cust in ct.tblCustomers
                            where cust.AccountID == ids.accountID
                            join mem in ct.tblCustomerMemberships
                            on cust.CustomerID equals mem.CustomerID
                            select new 
                                  { cust.CustomerID, 
                                    cust.Mobile, 
                                    cust.BusinessPhone, 
                                    cust.Code, 
                                    cust.Email, 
                                    cust.HomePhone, 
                                    mem.Membership, 
                                   Name = cust.FirstName + cust.LastName 
                                 };
    if(drpFilter.SelectedValue == "Code")
       customers.OrderByDescending(x=>x.Code);
