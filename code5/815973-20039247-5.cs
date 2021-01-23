    private int CurrentQuestionEnumerator { get; set; }
    private ObservableCollection<QuizGroup> _allQuizGroups;
    public ObservableCollection<QuizGroup> AllQuizGroups
    {
        get { return _allQuizGroups ?? (_allQuizGroups = new ObservableCollection<QuizGroups>); }
        set { _allQuizGroups = value; }
    }
    public QuizGroup CurrentQuizGroup { get; set; }
    private void nextbtn_Click(object sender, RoutedEventArgs e)
    {
        var sectorId = new QuizArgs
        {
            sector = "Food Production",
            question = CurrentQuizGroup [CurrentQuestionEnumerator++],
            Total = 0
        };
        this.Frame.Navigate(typeof(Quiz), sectorId);
    }
