    public class StudentPersonalInfo
    {
          public string StudentFirstName { get; set; }
          public string StudentLastName { get; set; }
          public int Age { get; set; }
          public string BloodGroup { get; set; }
          public string Address { get; set; }
    }
    
    public class EducationQualification
    {
          public string Graduation { get; set; }
          public int Grad_Marks_obtain { get; set; }
    
          public DateTime Grad_passing_year { get; set; }
          public string PostGraduation { get; set; }
    
          public int PG_Marks_obtain { get; set; }
          public DateTime PG_passing_year { get; set; }
    }
    public class StudentInfo
    {
       public StudentPersonalInfo PersonalInfo {get;set;}
       public EducationQualification EducationalQualification {get;set;}
    }
