    private void pageRoot_Loaded(object sender, RoutedEventArgs e)
    {
        Tuple<int, int, int> result = Methods.AddLevels(AddLevel, Question1, Question2, Answer);
        QuestionText1.Text = System.Convert.ToString(result.Item1);
        QuestionText2.Text = System.Convert.ToString(result.Item2);
    }
