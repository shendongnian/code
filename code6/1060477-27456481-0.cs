    List<Case> Cases = new List<Case>() 
            {
                new Case(){ Year = 2001, Agency = "Agency1", Attorney="Atticus Finch", CaseNumber = 1},
                new Case(){ Year = 2001, Agency = "Agency1", Attorney="Atticus Finch", CaseNumber = 2},
                new Case(){ Year = 2001, Agency = "Agency1", Attorney="Ben Matlock", CaseNumber = 3},
                new Case(){ Year = 2002, Agency = "Agency1", Attorney="Atticus Finch", CaseNumber = 99},
                new Case(){ Year = 2002, Agency = "Agency1", Attorney="Ben Matlock", CaseNumber = 22},
                new Case(){ Year = 2002, Agency = "Agency2", Attorney="Johnny Cochran", CaseNumber = 12},
                new Case(){ Year = 2003, Agency = "Agency2", Attorney="Mark Geragos", CaseNumber = 14},
                new Case(){ Year = 2003, Agency = "Agency3", Attorney="Robert Shapiro", CaseNumber = 29}
            };
    
    public class Case {
        public int CaseNumber { get; set; }
        public int Year { get; set; }
        public string Agency { get; set; }
        public string Attorney { get; set; }
    
    }
