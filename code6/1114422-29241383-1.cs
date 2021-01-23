    private static void TestCodeReadability2()
    {
        EmployeeDepartmentsConnection context = new EmployeeDepartmentsConnection();
        var accountsDepartments = context.Set<Department>().Where(isAccountsDepartment);
        var hrDepartments= context.Set<Department>().Where(isHumanResourcesDepartment);
        var combined = accountsDepartments.Union(HRDepartments);
    }
