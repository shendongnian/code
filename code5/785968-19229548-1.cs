    public class TestScore
    {
        public int ID { get; set; }
        public int TYPE { get; set; }
        public int SCORE { get; set; }
        public string SUBJECT { get; set; }
    }
    
    List<TestScore> testScores = new List<TestScore>{
        new TestScore{ ID = 0, SUBJECT = "MATH", SCORE = 10},
        new TestScore{ ID = 1, SUBJECT = "MATH", SCORE = 20},
        new TestScore{ ID = 2, SUBJECT = "ENGLISH", SCORE = 10},
        new TestScore{ ID = 3, SUBJECT = "ENGLISH", SCORE = 20},
        new TestScore{ ID = 4, SUBJECT = "ENGLISH", SCORE = 30},    
    };
    var tsList = from ts in testScores 
                 group new {ts.SUBJECT,ts.SCORE} by ts.SUBJECT into grp 
                 select new { Subject = grp.Key, Subtotal = grp.Sum(x => x.SCORE) };
    foreach(var t in tsList)
        Console.WriteLine("Subject: {0} - Subtotal: {1}", t.Subject, t.Subtotal);
    Console.WriteLine("Press Any Key to Exit...");    
    Console.ReadKey();
