    dynamic expandoObject = new ExpandoObject();
    
    for (int i = 0; i < 100; i++)
    {
        ((IDictionary<string, object>) expandoObject)["x" + i] = i;
    }
    
    Console.WriteLine(expandoObject.x1);  //Will write 1
    Console.WriteLine(expandoObject.x2);  //Will write 2
    Console.WriteLine(expandoObject.x50); //Will write 50
