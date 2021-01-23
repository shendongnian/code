       public class StudentChild : Student
       {
        [Display(Name="User name")]
        public String FullName
        {
            get { return FirstName + ", " + SecondName; }
        }
      }
    
