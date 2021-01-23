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
