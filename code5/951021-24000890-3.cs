    public class EmployeeManager
    {
        public int empmgr_id { get; set; }
        public int emp_id { get; set; }
        public int mgr_id{ get; set; }
        public IEnumerable<int> Employees
        {
            get
            {
                return this.GetEmployees(emp_id);
            }
        }
        public EmployeeManager(int emid, int eid, int mid)
        {
            empmgr_id = emid;
            emp_id = eid;
            mgr_id= mid;
        }
    }
