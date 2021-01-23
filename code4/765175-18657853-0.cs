    public class EmployeeDC
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLocation { get; set; }
    }
    
    public class EmployeeConverter : ITypeConverter<object, EmployeeDC>
    {
        public EmployeeDC Convert(ResolutionContext context)
        {
            var model = context.SourceValue;
    
            var employeeId = ???;
            var employeeName = ???;
            var employeeLocation = ???;
    
            return new EmployeeDC
                       {
                           EmployeeId = employeeId,
                           EmployeeName = employeeName,
                           EmployeeLocation = employeeLocation
                       };
        }
    }
    
    Mapper.CreateMap<object, EmployeeDC>()
          .ConvertUsing<EmployeeConverter>();
