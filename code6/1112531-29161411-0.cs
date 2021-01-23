    public class Student : Person
    {
        // This will make sure the value is initially defined (to 0):
        public Student(){
            CreditsEarned = 0;
        }
    
        ...
        // Credits earned
        [Display(Name = "Credits Earned")]
        public double CreditsEarned { get; set; }
