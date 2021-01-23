    foreach (var item in searchValList.Items)
    {
        while ((line = file.ReadLine()) != null)
        {
            if (line.Contains(item.ToString()))
            {
               sb.AppendLine(line.ToString());
               resultsTextBox.Text = sb.ToString();
            }
            else
            {
               resultsTextBox.Text = "The value was not found in this file";
            }
        }
    }
