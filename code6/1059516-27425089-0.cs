    private static Employee GetNode(Employee objEmployeeList, string id)
    {
        if (objEmployeeList.ChildOrg != null)
            foreach (var employee in objEmployeeList.ChildOrg)
            {
                if (employee.ID.Equals(id))
                    return employee;
    
                var employee = GetNode(employee.ChildOrg, id);
                
                if (employee != null)
                    return employee;
            }
        
        return null;
    }
