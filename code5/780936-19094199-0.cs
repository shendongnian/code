    public class Person
    {
        public string Name;
        public string Nationality;
        public bool New;
    }
    public class Department
    {
        public List<Person> EmployeeList;
        public void Add(Person person)
        {
            if (EmployeeList == null)
                EmployeeList = new List<Person>();
            EmployeeList.Add(person);
        }
        public int GetNewPersonCount
        {
            get
            {
                int count = 0;
                if (EmployeeList != null)
                {
                    foreach (Person p in EmployeeList)
                    {
                        if (p.New)
                            count++;
                    }
                }
                return count;
            }
        }
    }
    public class Company
    {
        public List<Department> DepartmentList;
        public void Add(Department department)
        {
            if (DepartmentList == null)
                DepartmentList = new List<Department>();
            DepartmentList.Add(department);
            
        }
        public int GetNewPersonCount
        {
            get
            {
                int count = 0;
                if (DepartmentList != null)
                {
                    foreach (Department d in DepartmentList)
                    {
                        count += d.GetNewPersonCount;
                    }
                }
                return count;
            }
        }
    }
