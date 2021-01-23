    CompanyEntities DbCompany = new CompanyEntities();
 
    foreach (Employee Emp in employees)
    {
        Employee Existed_Emp = DbCompany.Employees.Find(Emp.ID);
        Existed_Emp.Name = Emp.Name;
        Existed_Emp.Gender = Emp.Gender;
        Existed_Emp.Company = Emp.Company;
    }
 
    DbCompany.SaveChanges();
    return View();
}
