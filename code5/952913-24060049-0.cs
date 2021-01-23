    public static string UpdateEmployee(Employee employee)
    {
        using (var db = new RandDEntities())
        {
             db.Employees.Attach(employee);
             db.Entry(employee).State = EntityState.Modified;
             db.SaveChanges();
        }
        return "";
    }
