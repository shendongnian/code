    class2.cs //getters and setters
    
       public class Person
        {
            // Member Variables
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string DateOfBirth { get; set; }
            public string Gender { get; set; }
        }
        public class _Student : Person //student inherits from Person class
        {
            public string StudentNumber { get; set; }
            public DateTime EnrollmentDate { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string AwardID { get; set; }
            public string[] modules { get; set; }
        }
