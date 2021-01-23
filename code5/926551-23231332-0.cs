    public class UserScore
    {
         public string Name { get; private set; }
         public int Score { get; private set; }
         //. . .
    }
    var sortedScores = from userScore in MyFriendScores
                       orderby Math.Abs(userScore.Score - myScore), userScore.Score > myScore ? -1 : +1
                       select userScore;
