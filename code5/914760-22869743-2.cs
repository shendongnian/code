       bool IsAppend = false;
       if ((sAnswer == "YES")||(sAnswer == "Y"))
        {
            IsAppend = true;
        }
        
        using(StreamWriter swName = new StreamWriter(sName, IsAppend))
        {
           for (int iI = 0; iI < sInsults.Length; iI++)
            swName.WriteLine(sInsults[iI]);
        }
