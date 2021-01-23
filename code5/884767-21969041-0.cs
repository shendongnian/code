    public class StudentViewModel
    {
            public int StudentId { get; set; }
    
            public string Name { get; set; }
    
            //..other member variables..
    
            [Display(Name="Guardian"]
            public int GaurdianId { get; set; }
            public virtual IEnumerable<StudentGaurdian> Guardians { get; set; }
    
    }
