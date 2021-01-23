    System.Text.StringBuilder theStringBuilder = new System.Text.StringBuilder();
    foreach (KeyValuePair<string, int> kvp in Comparer)
    {
        if (kvp.Value != 0)
        {
            mismatches++;
            string InWhich = kvp.Value > 0 ? firstFile : secondFile;
            theStringBuilder.AppendLine("Extra value \n"+kvp.Key+" \nfound in file " + InWhich);
            if (Math.Abs(kvp.Value) != 1)
                theStringBuilder.AppendLine( Math.Abs(kvp.Value)+ "times");
            }
        }
    }
