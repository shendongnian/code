    class Department 
    { 
        public Department(Dep departmentType, IEnumerable<Position> positions, int employeeCount)
        {
            this.departmentType = departmentType;
            this.positions = new List<Position>(positions);
            this.employeeCount = employeeCount;
        }
    
        Dep departmentType; 
        List<Position> positions; 
        int employeecount;
    }
