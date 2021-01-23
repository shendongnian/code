    public partial class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentFullName { get; set; }
    public bool IsValid()
    {
     return !string.IsNullOrEmpty(this.DepartmentCode) &&  !string.IsNullOrEmpty(this.DepartmentFullName);
    }
    }
