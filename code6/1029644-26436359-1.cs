    private void button_Click(object sender, RoutedEventArgs e)
    {
        var moveTopUpDuration = TimeSpan.FromSeconds(1);
        var storyboard = new Storyboard();
    
        var moveTopUp = new ThicknessAnimation(
                            new Thickness(0, -40, 0, 0), 
                            moveTopUpDuration);
        Storyboard.SetTarget(moveTopUp, testCanvas);
        Storyboard.SetTargetProperty(moveTopUp, Canvas.MarginProperty);
        moveTopUp.Completed += MoveTopUpCompleted;
        var moveTopDown = new ThicknessAnimation(
                              new Thickness(0, 0, 0, 0),
                              TimeSpan.FromSeconds(1));
        Storyboard.SetTarget(moveTopDown, testCanvas);
        Storyboard.SetTargetProperty(moveTopDown, Canvas.MarginProperty);
        moveTopDown.BeginTime = moveTopUpDuration;
        storyboard.Childeren.Add(moveTopUp);
        storyboard.Childeren.Add(moveTopDown);       
        
        storyboard.Begin();
    }
    private void MoveTopUp_Completed(object sender, EventArgs e)
    {
        testLabel.Content = "ANIMATION TEST";
    }
