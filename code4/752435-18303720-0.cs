    string name = System.Console.ReadLine();
    string textContent = "";
    string dir = @"D:\Users\Jack\Documents\Test"; 
    if(name.Equals("Jack", StringComparison.OrdinalIgnoreCase))
    {
        textContent = File.ReadAllText(Path.Combine(dir, "Jack.txt"));
    }
    else if(name.Equals("Ken", StringComparison.OrdinalIgnoreCase))
    {
        textContent = File.ReadAllText(Path.Combine(dir, "Ken.txt"));            
    }
    else if(name.Equals("Jack", StringComparison.OrdinalIgnoreCase))
    {
        textContent = File.ReadAllText(Path.Combine(dir, "Wizard.txt"));
    }
    else
    {
         // output error or ask for another name
    }
    System.Console.WriteLine(" ");
    System.Console.WriteLine("{0}", textContent);
