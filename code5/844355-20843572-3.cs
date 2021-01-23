    private void ViewQuestions(StackPanel sp)
    {
        
        var stackPanel=gp.Content as StackPanel;
        if(stackPanel!=null)
        {
          StackPanel sp1 = new StackPanel { Orientation = Orientation.Vertical };
            sp1.Children.Add(stackPanel);
            sp1.Children.Add(sp);
           stackPanel.Children.Add(sp1 );
         }
        else
           gp.Content=sp; 
    }
