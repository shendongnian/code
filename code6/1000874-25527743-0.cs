    private void Button_Click(object sender, RoutedEventArgs e)
    {
    	//assuming that you're using List of Question class model.
    	var questions = (List<Question>)formDetails.ItemsSource;
    	//for this purpose ObservableCollection is preferable than List btw
    	.....
    }
