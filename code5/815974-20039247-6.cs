    private int CurrentQuestionEnumerator { get; set; }
    public ObservableCollection<QuizGroups>  AllQuestions { get; set; }
    private void nextbtn_Click(object sender, RoutedEventArgs e)
    {
        var sectorId = new QuizArgs
        {
            sector = "Food Production",
            question = AllQuestions[CurrentQuestionEnumerator++],
            Total = 0
        };
        this.Frame.Navigate(typeof(Quiz), sectorId);
    }
