    private void Button_Click(object sender, RoutedEventArgs e)
    {
    	phNumChoseTask.Completed += (o, result) => UpdateText(PersonNo1, result);
    	phNumChoseTask.Show();
    }
    
    private void Button1_Click(object sender, RoutedEventArgs e)
    {
    	phNumChoseTask.Completed += (o, result) => UpdateText(PersonNo2, result);
    	phNumChoseTask.Show();
    }
    
    private void UpdateText(TextBox textBox, PhoneNumberResult result)
    {
    	if (result.TaskResult == TaskResult.OK)
    		textBox.Text = result.PhoneNumber;
    }
