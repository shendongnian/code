    var list = new List<ICustomerHead>();
    var query = from p in context.Persons
                join c in context.Companies on p.CompanyId equals c.CompanyId
                where p.IsProvider.Equals(false) 
                      && p.Obsolete.Equals(false) 
                      && p.Locked.Equals(false) 
                      && p.IsCustomer.Equals(true)
                      && p.PersonType.Equals(2) // not sure why this was separate before?
                select new {p, c.StandardEmail};
    
    foreach(var item in query.ToList()) //ToList() causes the query to execute
    {
      var customer = item.p.ToSingleCustomerHead() //assume this is an extension method you've added?
      customer.Email = item.StandardEMail;
      list.Add(customer);
    }
