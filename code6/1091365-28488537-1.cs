    public class scoresClass
    {
        public int score = 0;
        public string name = "";
        public string quiz = "";
        public scoresClass(string userName, string userQuiz, int userScore)
        {
            name = userName;
            score = userScore;
            quiz = userQuiz;
        }
    }
    private List<scoresClass> importScoresFromFile(string path)
    {
        var listOfScores = new List<scoresClass>();
        var rawScores = File.ReadAllLines(path);
        foreach (var score in rawScores)
        {
            string[] info = score.Split('\t');
            listOfScores.Add(new scoresClass(info[0], info[1], Convert.ToInt32(info[2])));
        }
        return listOfScores.OrderByDescending(r => r.score).ToList();
    }
