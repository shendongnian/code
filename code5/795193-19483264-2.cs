    public class ActionResultToCoreConverter : ITypeConverter<ActionResult, Core>
    {
        public Core Convert(ResolutionContext context)
        {
            var result = (ActionResult)context.SourceValue;
            var employee = result.Employee;
            var core = (Core)context.DestinationValue ?? new Core();
            var employeeToUpdate = 
                core.Employees.FirstOrDefault(e => e.Name == employee.Name);
            Mapper.Map(employee, employeeToUpdate);
            return core;
        }
    }
