    String s = "abc055667788abc";
    string phoneNumber;
    foreach(char c in s)
    {
        if(Char.isNumber(c) || c == " " || c == "+")
        {
            phoneNumber = phoneNumber + c;
            minimumDigits++;
            if(minimumDigits >= 9)
            {
                NumberDetected(phoneNumber);
            }
        }
        else
        {
            minimumDigits = 0;
        }
    }
    NumberDetected(string rawNumber)
    { 
        int plusses = 0;
        foreach(char c in rawNumber)
        {
            if(c == "+")
            {
                plusses++;
            }
        }
        if(plusses <= 1)
        {
            if(rawNumber.StartsWith("+")
            {
                NumberDone(rawNumber);
            }
        }
        else
        {
            MessageBox.Show("Number contained too many plusses!");
        }
    }
