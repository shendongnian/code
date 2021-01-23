    private int CurrentQuestionEnumerator { set; get; }
    private void nextbtn_Click(object sender, RoutedEventArgs e)
    {
        var sectorId = new QuizArgs
        {
            sector = "Food Production",
            question = QuestionList[CurrentQuestionEnumerator++],
            Total = 0
        };
        this.Frame.Navigate(typeof(Quiz), sectorId);
    }
