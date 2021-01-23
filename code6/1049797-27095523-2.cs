    var professors = new List<Professor> 
            { 
                new Professor{
                    ProfessorID = 1,
                    Name = "John Doe",
                    Department = SeedDepartments().FirstOrDefault(),
                    Tenured = true
                }
            };
