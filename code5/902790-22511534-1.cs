    foreach (ListBoxItem listBoxItem in MyListBox.Items)
    {
        ContentPresenter presenter = FindVisualChild<ContentPresenter>(listBoxItem);
        DataTemplate dataTemplate = presenter.ContentTemplate;
        if (dataTemplate != null)
        {
            // Do something with dataTemplate here
        }
    }
