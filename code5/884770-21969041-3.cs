    public class StudentViewModel
    {
            public int StudentId { get; set; }
    
            public string Name { get; set; }
    
            //..other member variables..
    
            [Display(Name="Guardian"]
            public int GuardianId { get; set; }
            public virtual IEnumerable<StudentGuardian> Guardians { get; set; }
    
    }
