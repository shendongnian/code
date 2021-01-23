    var bindings = s.Bindings;
    var bindingCollection = new List<Binding>(bindings);
    foreach (Binding b in bindingCollection)
    {
        Console.WriteLine("\n Bindings: {0}", b.EndPoint);
        if (b.EndPoint != null)
        {
            //Hard Coded IP for testing purpose
            if (b.EndPoint.ToString() == "1.1.1.1:86")
            {
                Console.WriteLine("Removing this ip : {0}", b.EndPoint.ToString());
                bindings.Remove(b);
            }
        }
    }
