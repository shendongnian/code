    private int getNumber(string parentNodeHeader)
    {
        int curNumber = 0;
    
        //Required string-analysis actions
        //Sample functionality: extract all the numbers in the given string
        string outString = "";
        int count = -1;
        do
        {
            count = count + 1;
            Char curChar = Convert.ToChar(parentNodeHeader.Substring(count, 1));
            if (Char.IsNumber(curChar))
            {
                outString = outString + parentNodeHeader.Substring(count, 1);
            }
        } while (count < parentNodeHeader.Length - 1);
    
        if (outString != "")
        {
            curNumber = Convert.ToInt32(outString);
        }
    
        return curNumber;
    }
