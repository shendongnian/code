    public static IEnumerable<int> GetEmployees(this EmployeeManager mgr, int mgrID)
    {
        return EmpMgrData.EmpMgrList()
            .Where(mgr => mgr.mgr_id = mgrID)
            .Select(mgr => mgr.emp_id);
    }
