    public class Student{
     [Key]
     public int Studentid {get; set;}
     public string fname{get; set;}
     public string lname{get; set;}
     public virtual ICollection<Enrollement> Enrollement_E{ get; set; }
     }
    
     public class Enrollement{
     [Key]
     public int EnrolId {get; set;}
     [ForeignKey("Studentid ")]
     public int Student{get; set;}
     public string kk{get; set;}
     public virtual Student Student_E { get; set; }
     }
