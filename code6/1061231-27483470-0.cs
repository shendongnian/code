    static void Main(string[] args)
    {
       XElement xelement = XElement.Load("Employees.xml");
       IEnumerable<XElement> employees = xelement.Elements();
       Console.WriteLine("List of all Employee Names along with their ID:");
       foreach (var employee in employees)
       {     
          Console.WriteLine("EmpId: {0}", employee.Element("EmpId").Value);
          Console.WriteLine("SEX: {0}", employee.Element("Sex").Value);
         //Console.WriteLine("Home: {0}", employee.Element("Phone").Value);
          Console.WriteLine("Home: {0}", employee.Elements("Phone")
                   .Single(x => x.Attribute("Type").Value == "Home").Value);
          Console.WriteLine("Home: {0}", employee.Elements("Phone")
                   .Single(x => x.Attribute("Type").Value == "Work").Value);
         //Console.WriteLine("Work: {0}\n", employee.Element("Phone").Value);
       }
       Console.Read();
    }
