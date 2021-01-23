    class EmployeeAuthenticationService implements AuthenticationService {
        public void authenticate(Employee employee, String password) {
            if (employee.Authenticate(password)) {
                // do stuff
                employeeRepository.Update(myEmployee);   
            }
        }            
    }
