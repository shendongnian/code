    IEnumerable<TextBox> containerTextboxes = myContainer.Children.OfType<TextBox>();
    int initialCounter = containerTextboxes.Count();
    int distinctCounter = containerTextboxes.Select(tb => tb.Text).Distinct();
    if (initialCounter == distinctCounter)
    {
        // No duplicates
    }
    else
    {
        // There are duplicates
    }
