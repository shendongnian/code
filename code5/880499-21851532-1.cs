    public class Grade
    {
        public string Name;
        public int Count;
        public int ScoreMin;
        public int ScoreMax;
        public bool Test(int score) { return score >= ScoreMin && score <= ScoreMax; }
 
		public static readonly Grade Excellent = new Grade() {Name = "Excellent", ScoreMin = 90, ScoreMax = 100};
		public static readonly Grade Good = new Grade() {Name = "Good", ScoreMin = 70, ScoreMax = 89};
		
		public static readonly Grade[] GetAll = new Grade[] { Excellent, Good };
    }	
    private static string GetGrade(int examScore)
    {
        foreach(var grade in Grade.GetAll)
            if(grade.Test)
            {
                grade.Count++;
                return grade.Name;
            }
        return "Invalid";
    }
    // report
    foreach(var grade in Grade.GetAll)
        Console.WriteLine(grade.Name + "," + grade.Count);
