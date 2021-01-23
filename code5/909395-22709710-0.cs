    public class Student : UserProfile
    {
        public int StudentId { get; set; }
        public virtual GraduationWork GraduationWork { get; set; }       
    }
    public class GraduationWork
    {
        [Key]
        [ForeignKey("Student")]        
        public int StudentID { get; set; }       
        public virtual Student Student { get; set; }
    }
