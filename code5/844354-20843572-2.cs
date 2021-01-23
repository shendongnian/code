    private void ViewQuestions(StackPanel sp)
    {
        var stackPanel=gp.Content as StackPanel;
        if(stackPanel!=null)
           stackPanel.Children.Add(sp);
        else
           gp.Content=sp; 
    }
