    private void pageRoot_Loaded(object sender, RoutedEventArgs e)
    {
        Tuple<int, int, int> result = Methods.AddLevels(AddLevel, Question1, Question2, Answer);
        QuestionText1.Text = System.Convert.ToString(result.Item1);
        QuestionText2.Text = System.Convert.ToString(result.Item2);
    }
    public static Tuple<int, int, int> AddLevels(int addLevel, int question1, int question2, int answer)
    {
        if (addLevel == 0 || addLevel == 1)
        {
            Random rnd = new Random();
            question1 = rnd.Next(0, 10);
            question2 = rnd.Next(0, 10);
            answer = question1 + question2;
        }
        return Tuple.Create(question1, question2, answer);
    }
