    dynamic a = new Class();
    a.Age = 18;
    a.Name = "Jon";
    a.Product = new Product();
    
    a.Name; // read a string
    a.Age; // read an int
    a.Product.Name; // read a property
    a.Product.MoveStock(-1); // call a method from Product property.
