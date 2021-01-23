    DependencyObject dobj = validationContentPresenter.Content as DependencyObject;
    if (dobj != null)
    {
        foreach (FrameworkElement o in
            GetAllVisualChildren(dobj).OfType<FrameworkElement>())
        {
        }
    }
