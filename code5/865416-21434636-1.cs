    // Getting the ContentPresenter from the ViewControl
    ContentPresenter myContentPresenter = 
        VisualTreeHelper.GetChild(ViewControl, 0) as ContentPresenter;    
    if (myContentPresenter != null)
    {
        // Finding View from the DataTemplate that is set on that ContentPresenter
        DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
        MyView myView = (MyView)myDataTemplate.FindName("View", myContentPresenter);
    
        // Do something to the myView control here
    }
