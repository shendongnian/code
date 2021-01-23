    string Choice = Console.ReadLine();
    if(!string.IsNullOrEmpty(Choice))
    {
       var filteredEmployees = employees.Where(e => e.eventHeld == Choice);
       foreach(Employee e in filteredEmployees)
       {
           Console.WriteLine(e);
       }
    }
