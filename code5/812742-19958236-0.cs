    private void TreeView_Checked(object sender, RoutedEventArgs e)
    {
    	CheckBox chkBox = sender as CheckBox;
    	StackPanel stackPanel = chkBox.Parent as StackPanel;
    	TextBlock txtBlock = FindVisualChild<TextBlock>(stackPanel);
    	Hyperlink hyperlink = FindVisualChild<Hyperlink>(stackPanel);
        TextBlock secondTextBlock = FindVisualChild<TextBlock>(hyperlink);
    	bool isChecked = chkBox.IsChecked.HasValue ? chkBox.IsChecked.Value : false;
    
    	if (isChecked)
    	{  
    	    selectedNames.Add(txtBlock.Text);   
    	    selectedNames.Add(secondTextBlock.Text);           
    	}       
    }
