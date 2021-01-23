    public void HandleAnswer(QuestionType qt)
    {
        if (qt.Answer is Boolean)
        {
            //do boolean stuff
        }
        else if (qt.Answer is String)
        {
            //do string stuff
        }
        else if (qt.Answer is Int32)
        {
            //do int stuff
        }
        //do unknown object stuff
    }
