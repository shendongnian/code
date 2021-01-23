    int counter = 1; // start at 1 so that the counter is in line with the number of items that the loop has iterated over (instead of 0 which would be better for indexing into the collection)
    List<ListItem> selectedItems = new List<ListItem>();
    foreach (ListItem li in attendees.Items)
    {
        if (li.Selected)
        {
            selectedItems.Add(li);
        }
    }
    foreach (ListItem li in selectedItems)
    {
        counter++;
        if (attendeed.SelectedItems.Count > 1 && i == attendees.Count) // check after the counter has been incremented so that only the last item triggers it
        {
            people += " and";
        }
        people += li.Text + " ";
    }
