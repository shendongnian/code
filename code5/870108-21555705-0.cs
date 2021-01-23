    // order
    List<UserScore> scores = new List<UserScore>(listBox.Items.Cast<UserScore>());
    var orderedScores = scores.OrderBy(li => li.Score).ToList<UserScore>();
    
    // re-populate the ListBox
    listBox.Items.Clear();
    listBox.Items.AddRange(orderedScores.ToArray<UserScore>());
    public class UserScore
    {
        public string UserName { get; set; }
        public int Score { get; set; }
    }
