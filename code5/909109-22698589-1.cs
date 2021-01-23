    public List<Student> allStudents(string User_name, string _password)
    {
            List<Student> st = new List<Student>{
            new Student { StudentNumber="CE52103-2", 
                FirstName ="AAA", 
                LastName = "BBB", 
                UserName = "CCC",
                Password ="DDD", 
                DateOfBirth = "",
                Gender ="",
                AwardID =""},
       
            new Student { StudentNumber="CE52603-2", 
                FirstName ="BBB", 
                LastName = "DDD" , 
                UserName = "FFF",
                Password ="GGG", 
                DateOfBirth = "",
                Gender = "",
                AwardID =""},
    
            new Student { StudentNumber="CE52302-2", 
                FirstName ="GGG", 
                LastName = "HHH", 
                UserName = "KKK",
                Password ="LLL", 
                DateOfBirth = "",
                Gender ="",
                AwardID =""},
            };
           return st;
    }
