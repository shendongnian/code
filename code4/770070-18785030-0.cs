    /**Reverse a Sentence without using C# inbuilt functions
     (except String.Length property, m not going to write code for this small functionality )*/
    const char EMPTYCHAR = ' ';
    const string EMPTYSTRING = " ";
    
    /// <summary>
    /// Reverse a string Sentence
    /// </summary>
    /// <param name="pStr"></param>
    /// <returns></returns>
    public string ReverseString(string pStr)
    {
      if (pStr.Length > 1) //can be checked/restricted via validation
      {
        string strReversed = String.Empty;
        string[] strSplitted = new String[pStr.Length];
        int i;
    
        strSplitted = Split(pStr); // Complexity till here O(n)
    
        for (i = strSplitted.Length - 1; i >= 0; i--)
        // this for loop add O(length of string) in O(n) which is similar to O(n)
        {
            strReversed += strSplitted[i];
        }
    
        return strReversed;
      }
      return pStr;
    }
    
    /// <summary>
    /// Split the string into words & empty spaces
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public string[] Split(string str)
    {
        string strTemp = string.Empty;
        string[] strArryWithValues = new String[str.Length];
        int j = 0;
        int countSpace = 0;
    
        //Complexity of for conditions result to O(n)
        foreach (char ch in str)
        {
            if (!ch.Equals(EMPTYCHAR))
            {
                strTemp += ch; //append characters to strTemp
    
                if (countSpace > 0)
                {
                    strArryWithValues[j] = ReturnSpace(countSpace); // Insert String with Spaces
                    j++;
                    countSpace = 0;
                }
            }
            else
            {
                countSpace++;
    
                if (countSpace == 1)
                {
                    strArryWithValues[j] = strTemp; // Insert String with Words
                    strTemp = String.Empty;
                    j++;
                }
            }
        }
    
        strArryWithValues[j] = strTemp;
        return (strArryWithValues);
    }
    
    /// <summary>
    /// Return a string with number of spaces(passed as argument)
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public string ReturnSpace(int count)
    {
        string strSpaces = String.Empty;
    
        while (count > 0)
        {
            strSpaces += EMPTYSTRING;
            count--;
        }
    
        return strSpaces;
    
    }
    
    /************Reverse Sentence Ends***************/
