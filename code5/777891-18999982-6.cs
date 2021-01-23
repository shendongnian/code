    public bool SaveDepartment(Department newDepartment)
        {
            if (string.IsNullOrEmpty(newDepartment.DepartmentCode))
            {
                throw new ArgumentException("DepartmentCode must be not null");
            }
            repository.Add(newDepartment);
            _UoW.Save();
            return true;
        }
