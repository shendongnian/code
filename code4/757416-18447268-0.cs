    string sentence = "My name is so and so. I am a graduation student. I know c, c++, java and sql server.";
    string[] words = sentence.Split();
    var matchingItems = DropDownList1.Items.Cast<ListItem>()
        .Where(li => words.Any(w => li.Text.IndexOf(w, StringComparison.OrdinalIgnoreCase) >= 0));
    foreach(ListItem item in matchingItems)
        DropDownList2.Items.Add(item.Text);
