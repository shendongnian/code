        public DepartmentCollection AddDept(string d, Employee e)
        {
            if (!ContainsKey(d))
            {
                Add(d, new SortedSet<Employee>(new EmployeeComparer()));
            }
            this[d].Add(e);
            return this;
        }
