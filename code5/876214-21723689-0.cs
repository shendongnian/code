    While(!RightAnswerFunc())
    {
        //Wrong. Retry.
    }
    private static bool RightAnswerFunc()
    {
        bool isValid = false;
        if(yourStringValue == Console.ReadLine())
        {
              isValid = true;
        }
        return isValid;
    }
