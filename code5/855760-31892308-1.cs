    using Dapper.FluentMap.Mapping;
    
    namespace Repository.DTO
    {
        public class EmployeeModel
        {
            public int EmpId { get; set; }
    
            public string First { get; set; }
    
            public class EmployeeModelMap : EntityMap<EmployeeModel>
            {
                public EmployeeModelMap()
                {
                    Map(p => p.First).ToColumn("FirstName");
                }
            }
        }
    }
