    public class DepartmentInfo
    {
        private DateTime _startDate;
        private String _name;
        private Int32 _departmentID;
    
        public Int32 DepartmentID
        {
            get
            {
                return _departmentID;
            }
            set
            {
                _departmentID = value;
            }
        }
        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
            }
        }
    }
    
    public static void ExecuteStoreCommands()
    {
        using (SchoolEntities context =
            new SchoolEntities())
        {
    
            int DepartmentID = 21;
            // Insert the row in the Department table. Use the parameter substitution pattern.
            int rowsAffected = context.ExecuteStoreCommand("insert Department values ({0}, {1}, {2}, {3}, {4})",
                            DepartmentID, "Engineering", 350000.00, "2009-09-01", 2);
            Console.WriteLine("Number of affected rows: {0}", rowsAffected);
    
            // Get the DepartmentTest object. 
            DepartmentInfo department = context.ExecuteStoreQuery<DepartmentInfo>
                ("select * from Department where DepartmentID= {0}", DepartmentID).FirstOrDefault();
    
            Console.WriteLine("ID: {0}, Name: {1} ", department.DepartmentID, department.Name);
    
            rowsAffected = context.ExecuteStoreCommand("delete from Department where DepartmentID = {0}", DepartmentID);
            Console.WriteLine("Number of affected rows: {0}", rowsAffected);
        }
    }
