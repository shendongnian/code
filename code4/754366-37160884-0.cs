    > Here EmployeeDetail is a table name and Employee is a model name.  And
    > ID,Branch,Salary and UID is a table field
    
    
      public ActionResult Index()
                    {
                        List<EmployeeDetail> employees = context.EmployeeDetails.ToList();
                        List<Employee> emp = new List<Employee>();
                        foreach(EmployeeDetail item in employees)
                        {
                            emp.Add(new Employee
                                {
                                    ID=Convert.ToInt32(item.ID),
                                    Branch=item.Branch,`enter code here`
                                    Salary=Conve`enter code here`rt.ToInt32(item.Salary),
                                    UID = Convert.ToInt32(item.ID),
                                });
                        }
                        return View(emp);
                    }
    
    
    
    >  view page code
    
    
        <div style="font-family:Arial">
            <h2>Index</h2>
    
            <ul>
                @foreach (var emp in Model)
                {
                    <li>
                        @Html.ActionLink(emp.Branch, "Details", new { id = emp.ID });
                    </li>
                }
    
            </ul>
        </div>
