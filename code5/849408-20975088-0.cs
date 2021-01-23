            public class MyScenarioForm
            {
                [Key]
                public string FormName { get; set; }
                public int SelectedDesgId {get; set;}
                public int SelectedDeptId { get; set; }
    
                public IEnumerable<Designation> Designations { get; set; }
                public IEnumerable<Department> Departments { get; set; } 
    
                // ... constructor or method that creates initial instance with Designations and Departments populated
            }
