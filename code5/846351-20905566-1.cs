    using(MyContext context = new MyContext())
    {
        Department department = new Department()
        {
            Name = txtDepartment.text.trim()
        };
        context.Set<Department>().Add(department);
    }
    
