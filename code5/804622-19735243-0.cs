    public virtual string ExecutorDepartmentName
    {
        get { return ExecutorDepartment != null ? ExecutorDepartment.Name : null; }
    }
    public virtual IEnumerable<string> AdditionalExecutorDepartmentNames
    {
        get { return AdditionalExecutorDepartments.Select(x => x.Name); }
    }
