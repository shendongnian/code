        public class EmployeeModel
        {
            [Key]
            [ForeignKey("EmployeeRoles")]
            public decimal empid { get; set; }
            public string name { get; set; }
            public virtual List<EmpRoleModel> EmployeeRoles { get; set; }
        }
        public class RoleModel
        {
            [Key]
            public decimal roleid { get; set; }
            public string name { get; set; }
        }
        public class EmpRoleModel
        {
            [Key]
            [Column(Order = 0)]
            [ForeignKey("Employee")]
            public decimal empid { get; set; }
            [Key]
            [Column(Order = 1)]
            [ForeignKey("Role")]
            public decimal roleid { get; set; }
            public virtual EmployeeModel Employee { get; set; }
            public virtual RoleModel     Role     { get; set; }
        }
