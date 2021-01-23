    var firstFileChanges = new List<string>();
    var secondFileChanges = new List<string>();
    System.Text.StringBuilder theStringBuilder = new System.Text.StringBuilder();
    foreach (KeyValuePair<string, int> kvp in Comparer)
    {
        if (kvp.Value != 0)
        {
            mismatches++;
            string InWhich = kvp.Value > 0 ? firstFile : secondFile;
            if(InWhich == firstFile)
            {
                firstFileChanges.Add(kvp.Key);
            }
            else 
            {
                secondFileChanges.Add(kvp.Key);
            }
        }
    }
    if(firstFileChanges.Count > 0 )
    {
        theStringBuilder.Append("First file changes: ");
        int counter1 = 0;
        foreach(string change1 in firstFileChanges)
        {
            if(counter1 > 0)
            {
                theStringBuilder.Append(", ");
            }
            theStringBuilder.Append(change1);
            counter1 += 1;
        }
        theStringBuilder.AppendLine();
    }
    if(secondFileChanges.Count > 0 )
    {
        theStringBuilder.Append("Second file changes: ");
        int counter2 = 0;
        foreach(string change2 in secondFileChanges)
        {
            if(counter2 > 0)
            {
                theStringBuilder.Append(", ");
            }
            theStringBuilder.Append(change2);
            counter2 += 1;
        }
    }
    MessageBox.Show(theStringBuilder.ToString());
