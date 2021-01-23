    public static void SetAnswer(this answerObject instance, string question, string value)
    {
        var property = typeof(answerObject).GetProperty(question);
        if (property != null) property.SetValue(instance, value);
        else { // throw exception or display a message }
    }
