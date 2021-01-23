    List<string> list = new List<string>();
            
            list.Add("first line of string");
            list.Add("opening parenthesis here (");
            list.Add("third line of string");
            list.Add("making something here(blabla");
            list.Add("blabla)");
            list.Add("closing parenthesis here)");
            list.Add("last line of string(");
    
            string Result = "";
            int openingParIndex = -1;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Contains("("))
                    openingParIndex = i;
    
                if (openingParIndex > -1)
                {
                    if (list[i].Contains(")"))
                    {
                        Result += "Paranthese opened at " + openingParIndex + " and closed at " + i + " \n";
                        openingParIndex = -1;
                    }
                }
            }
            if(openingParIndex > -1)
                 Result += "Paranthese opened at " + openingParIndex + " and was never closed";
