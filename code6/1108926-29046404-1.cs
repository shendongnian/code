    var customer = new Customer();
    var props = customer.GetType().GetProperties();
    props[0].SetValue(customer, 1);
    props[1].SetValue(customer, "hamix");
    Console.WriteLine(props[0].GetValue(customer));
    Console.WriteLine(props[1].GetValue(customer));
