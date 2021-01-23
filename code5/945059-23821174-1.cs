    string checkboxes = " ";
    foreach (Control c in MyPanel.Controls)
    {
        if (c is CheckBox && (c as CheckBox).Checked)
            checkboxes += (c as CheckBox).Text.Split().Last();
    }
    checkboxes = string.Join(", ", checkboxes.Take(checkboxes.Count() - 1)) + (checkboxes.Count() > 1 ? " and " : "") + checkboxes.LastOrDefault();
    checkboxes = checkboxes.Remove(0, 1) ;
    Console.WriteLine("Items " + checkboxes + " are checked");
