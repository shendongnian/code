    private void pageRoot_Loaded(object sender, RoutedEventArgs e)
    {
        Methods.AddLevels(AddLevel, ref Question1, ref Question2, ref Answer);
        QuestionText1.Text = System.Convert.ToString(Question1);
        QuestionText2.Text = System.Convert.ToString(Question2);
    }
    public void AddLevels(int addLevel, ref int question1, ref int question2, ref int answer)
    {
        if (addLevel == 0 || addLevel == 1)
        {
            Random rnd = new Random();
            question1 = rnd.Next(0, 10);
            question2 = rnd.Next(0, 10);
            answer = question1 + question2;
        }
    }
