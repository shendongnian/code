      private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
     {
   
    ContentDialog testDialog = new ContentDialog()
    {
        Title = "Testing",
        Content = "We are still testing this contentDialog",
        PrimaryButtonText = "Ok"
    };
    await testDialog.ShowAsync();
 
    }
