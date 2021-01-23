    public static Tuple<int, int, int> AddLevels(int addLevel, int question1, int question2, int answer)
    {
        if (addLevel == 0 || addLevel == 1)
        {
            Random rnd = new Random();
            question1 = rnd.Next(0, 10);
            question2 = rnd.Next(0, 10);
            answer = question1 + question2;
        }
        return new Tuple<int, int, int>(question1, question2, answer);
    }
