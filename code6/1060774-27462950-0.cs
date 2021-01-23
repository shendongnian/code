    class Employee 
    {
      ....
      piblic string Name {get;set;}
    }
    Employee GetByName(string name)
    {
         return listOfAllEmployees.Where(e => e.Name = name);
    }
