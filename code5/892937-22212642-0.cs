    public List<string> EmployeeAccess2()
    {
    EmployeeAccess EA = new EmployeeAccess();
    View_HCM VH = new View_HCM();
    var x = from b in contxt.View_HCM
            where b.EmpNo == EA.EmpNo
            select b.EmailAddress;
    return x.ToList();
    }
