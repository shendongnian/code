        public DepartmentCollection AddDept(string d, Employee e)
        {
            if (ContainsKey(d))
            {
                this[d].Add(e);
            }
            else
            {
                Add(d, new SortedSet<Employee>(new EmployeeComparer()));
               // Add this!
               this[d].Add(e);
            }
            return this;
        }
