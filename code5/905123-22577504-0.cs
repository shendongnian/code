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
          public intGrad_Marks_obtain { get; set; }
    
          public DateTimeGrad_passing_year { get; set; }
          public stringPostGraduation { get; set; }
    
          public intPG_Marks_obtain { get; set; }
          public DateTimePG_passing_year { get; set; }
    }
    public class StudentInfo
    {
       public StudentPersonalInfo PersonalInfo {get;set;}
       public EducationQualification EducationalQualification {get;set;}
    }
