    public partial class DepartmentEFEntity    {
        public virtual Guid? DepartmentUUID { get; set; }
        public virtual string DepartmentName { get; set; }
        public virtual ICollection<EmployeeEFEntity> Employees { get; set; }
    }
    public partial class EmployeeEFEntity
    {
        public virtual Guid? ParentDepartmentUUID { get; set; }
        public virtual Guid? EmployeeUUID { get; set; }
        public virtual DepartmentEFEntity ParentDepartment { get; set; }
        public virtual string SSN { get; set; }
    }
    public class SuperWrapper
    {
    
        internal DepartmentEFEntity DeptProxy { get; private set; }
        internal EmployeeEFEntity EmpProxy { get; private set; }
    
        public SuperWrapper(DepartmentEFEntity dept, EmployeeEFEntity emp)
        {
            this.DeptProxy = dept;
            this.EmpProxy = emp;
        }
    
        public string DepartmentName
        {
            get { return null == this.DeptProxy ? string.Empty : this.DeptProxy.DepartmentName; }
            set { if(null!=this.DeptProxy{this.DeptProxy.DepartmentName =value;}}
        }
    
        public string EmployeeSSN
        {
            get { return null == this.EmpProxy ? string.Empty : this.EmpProxy.SSN; }
            set { if(null!=this.EmpProxy{this.EmpProxy.SSN =value;}}
        }
    
    }
