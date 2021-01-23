    var numbers = customers.SelectMany(
        customer => customer.PhoneNumbers.Select(
            number => new
            {
                Number = number, 
                FirstName = customer.BillToContact.FirstName,
                Email = customer.BillToContact.Email
            }));
