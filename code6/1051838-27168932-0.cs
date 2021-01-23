    public string AllPosition()
        {
            EmployeeService employeeService = new EmployeeService();
            List<Position> positions= employeeService.GetAllPosition();
            var x = JsonConvert.SerializeObject(positions);      
            return x;
        }
