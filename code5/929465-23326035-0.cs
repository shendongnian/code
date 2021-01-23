    while (line != null)
    {
        var q = new QuestionUnit();
        q.Question = line;
        line = thereader.ReadLine();
        q.Answer = line;
        line = thereader.ReadLine();
        q.CorrectAnswer = line;
        line = thereader.ReadLine();
        q.Explanation = line;
        m_Questions[counter] = q;
