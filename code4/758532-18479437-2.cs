    StringBuilder sb = new StringBuilder();
    foreach (KeyValuePair<string, int> kvp in Comparer)
    {
        if (kvp.Value != 0)
        {
            mismatches++;
            string InWhich = kvp.Value > 0 ? firstFile : secondFile;
            sb.AppendLine("Extra value \n" + kvp.Key + " \nfound in file " + InWhich + (Math.Abs(kvp.Value) != 1 ? ("\n" + Math.Abs(kvp.Value) + "times") : string.Empty)); 
        }
    }
    MessageBox.Show(sb.ToString());
