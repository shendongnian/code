    List<string> list = new List<string>();
        List<int> Opened = new List<int>();
        List<int> Closed = new List<int>();
        list.Add("first line of string");
        list.Add("opening parenthesis here (");
        list.Add("third line of string");
        list.Add("making something here(blabla");
        list.Add("blabla)");
        list.Add("closing parenthesis here)");
        list.Add("last line of string");
        
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Contains("("))
                Opened.Add(i);
            else if (list[i].Contains(")"))
                Closed.Add(i);
        }
        string Result = "";
        for (int i = 0; i < Opened.Count; i++)
        {
            Result += "Opened at " + Opened[i].ToString() + " and closed at " + (Closed[Closed.Count - i - 1]) + "\n";
        }
