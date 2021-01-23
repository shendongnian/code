    public class EmployeeRepository {
        public IEnumerable<Employee> GetAll() {
            // This function won't compile. I don't know the syntax for this type of LINQ
            using (var context = new SQL_TA_SCOREBOARDEntities1()) {
                return (from ea in context.View_SystemAdminMembers
                join vh in context.View_HCM on (Int16)ea.EmpNo
                join rl in context.EmployeeAccessLevels on ea.RoleID equals rl.id into outer_join
            }
        }
        public IEnumerable<Employee> GetAllEmployeesWithEmployeeId(int employeeId) {
            return GetAll().Where(e => e.Id == employeeId).ToList();
        }
        public IEnumerable<Employee> SomeOtherFunctionThatDoesWhatYouWantToDoFromThisPost() {
            // You could also create a class that extends IEnumerable<Employee> to
            // encapsulate the logic so that the repository doesn't have a million functions
        }
    }
