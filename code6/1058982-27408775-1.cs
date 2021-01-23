    private string allowed = "abc";
    private string userInput = "some string entered";
    bool stringIsValid = false;
    for (int i = 0; i < userInput.Length; i++)
    {
        if (!allowed.IndexOf(userInput[i]))
        {
            stringIsValid = false;
            break; // You can stop the loop upon the first occurance of an invalid char
        }
    }
