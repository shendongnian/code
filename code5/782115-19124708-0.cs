    string[] lines = File.ReadAllLines("...");
    var listboxItems = searchValList.Cast<object>().Select(x=> x.ToString()).ToList();
    foreach (var line in lines)
    {
        if (listboxItems.Any(x=> line.Contains(x)))
        {
            sb.AppendLine(line);
        }     
    }
    if(sb.Length > 0)
    {
        resultsTextBox.Text = sb.ToString();
    }
    else
    {
         resultsTextBox.Text = "The value was not found in this file";
    }
