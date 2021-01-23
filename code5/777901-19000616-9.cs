    public bool SaveDepartment(Department department)
    {
        try
        {
            repository.Add(department);
            _UoW.Save();
            return true;
        }
        catch (NonUniqueEntityException e)
        {
            // log exception
            return false;
        }            
    }
