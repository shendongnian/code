    public string Department
    {
        get
        {
            string departments = string.Empty;
            foreach (Department department in AssociatedDepartment)
            {
                if (departments.Length != 0)
                    departments += ", ";
                departments += department.DepartmentName;
            }
            return departments;
        }
    }
