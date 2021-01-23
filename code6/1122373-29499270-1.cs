    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    [WebMethod]
    public static List<Employee> GetEmployees(string lifeNumber)
    {
        PCF.Entities.Data.Entities db = new PCF.Entities.Data.Entities();
        var data = db.MasterTables
                    .Where(x => x.Life_Hosp == lifeNumber)
                    .Select(x => new Employee
                     {
                         FirstName = x.FirstName, 
                         LastName = x.LastName 
                     });
        return data.ToList();
    }
