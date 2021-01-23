    var selectedPeople = new List<string>();
    
    foreach (ListItem li in attendees.Items)
    {
        
        if (li.Selected)
        {
            people.Add(li.Text);
        }
        
    }
    var sb = new StringBuilder();
    if (selectedPeople.Count == 0)
    {
        sb.Append("");
    }
    else
    {
        for (var i = 0; i < selectedPeople.Count; i++)
        {
            if (i > 0)
            {
                sb.Append(" ");
                if (i == selectedPeople.Count)
                {
                    sb.Append("and ");
                }
            }
            sb.Append(selectedPeople[i]);
        }
    }
    
    
    ...
    
    confirmation.Text = r + " has been booked on " + d + " by " + n + " for " + en + ". " + sb.ToString() + " will be attending.";
