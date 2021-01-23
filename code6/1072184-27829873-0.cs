    public static async void LoadData()
        {
            using (MyEntities entities = new MyEntities())
            {
                List<Employee> Employees = await (from d in entities.Employees
                                            where d.Id > 100
                                            select new new Employee
                                            {
                                                Name = d.LastName + ", " + d.FirstName
                                                DoB = d.dob
                                            }).ToListAsync();
            }
    }
