    private Employee GetNode(Employee employee, string id)
    {
        if (employee.id.Equals(id))
        {
            return employee;
        }
        if (employee.ChildOrg != null)
        {
            foreach (var item in employee.ChildOrg)
            {
                return GetNode(item, id);
            }
        }
        return null;
    }
