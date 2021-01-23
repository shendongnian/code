    public class Employee
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public Employee Supervisor {get; set; }
    }
    public class EmployeeDto {
        public int Id {get; set;}
        public string Name { get; set; }
        public SupervisorDto Supervisor { get; set; }
        public class SupervisorDto {
            public int Id {get; set;}
            public string Name { get; set; }
        }
    }
    Mapper.CreateMap<Employee, EmployeeDto>();
    Mapper.CreateMap<Employee, EmployeeDto.SupervisorDto>();
