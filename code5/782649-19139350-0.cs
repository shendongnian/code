    var peopleList = new List<string>();
    
    foreach (ListItem li in attendees.Items)
    {
        if (li.Selected)
           peopleList.Add(li.Text);
    }
   
    var people = string.Join(",", list.Take(list.Count - 1));
    people += " and " + list.Last();
