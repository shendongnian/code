    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        AlertFrame.Content = null;
        AlertIsUp = false;
        QuestionResponse = false;
        if (OnButtonClick != null) OnButtonClick(QuestionResponse);
    }
    
    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        AlertFrame.Content = null;
        AlertIsUp = false;
        QuestionResponse = true;
        if (OnButtonClick != null) OnButtonClick(QuestionResponse);
    }
