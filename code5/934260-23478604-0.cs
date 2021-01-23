    private void tButton_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
    	tButton.IsChecked = !tButton.IsChecked.Value;
    	e.Handled = true;
    
    	//...
    }
 
