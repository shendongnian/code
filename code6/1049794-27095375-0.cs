    private static List<Department> departments;
    private static List<Professor> professors;
    private static List<Department> SeedDepartments()
    {
        if (departments == null)
        {
          departments = new List<Department> 
          { 
              new Department
              {
                DepartmentID = 1,
                Name = "Psychology"
              }
          };
        }
        return departments;
    }
    private static List<Professor> SeedProfessors()
    {
        if (professors == null)
        {
           professors = new List<Professor> 
           { 
              new Professor
              {
                ProfessorID = 1,
                Name = "John Doe",
                Department = SeedDepartments().Where(d => d.DepartmentID == 1), //SeedDepartments()[0],
                Tenured = true
              }
           };
        }
        return professors;
    }
