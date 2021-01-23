    dynamic x = new MyExpando();
    x.Name = "Darth Sidious";
    x.GreatDialog = "Something, something, darkside!";
    Console.WriteLine(x.Name + " says : \"" + x.GreatDialog + "\"");
    Console.ReadKey();
