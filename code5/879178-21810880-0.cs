    string CreateArrow(int count)
    {
        // Only one buffer
        StringBuilder sbAll = new StringBuilder();
        // The arrow needs an arrowhead
        if(count % 2 == 0) count++;
        // Create the arrowhead
        string s = new string('*', count);
        sbAll.AppendLine(s);
        // the rest of the arrow
        for(int x = count-1; x>0; x--)
        {
            s = new string('*', x);
            // before the arrowhead
            sbAll.Insert(0, s + Environment.NewLine);
            // after the arrowhead
            sbAll.AppendLine(s);
        
        }
        return sbAll.ToString();
    }
