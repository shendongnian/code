            List<Employee> emplist = new List<Employee>()
                    {
                     new Employee{Age=15, name = "Tom",project= new List<Project>
                     {
                        new Project{ID = 12, name = "Project A"},
                         new Project{ID = 11, name = "Project B"},
                         new Project{ID = 16, name = "Project C"}
                     }},
                     new Employee{Age=17, name = "Billy",project= new List<Project>
                     {
                         new Project{ID = 17, name = "Project D"},
                         new Project{ID = 18, name = "Project E"},
                         new Project{ID = 10, name = "Project F"}
                     }},
                     new Employee{Age=25, name = "Sam",project= new List<Project>
                     {
                         new Project{ID = 22, name = "Project X"},
                         new Project{ID = 24, name = "Project Y"},
                         new Project{ID = 19, name = "Project Z"}
                     }}
                    };
            Project pr = emplist.SelectMany(e => e.project).OrderBy(p => p.ID).LastOrDefault();
