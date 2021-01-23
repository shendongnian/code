    public MainPage()
    {
    	InitializeComponent();
    	phNumChoseTask = new PhoneNumberChooserTask();
    }
    
    private EventHandler<PhoneNumberResult> _chooserTaskHandler;
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
    	//detach current handler
    	phNumChoseTask.Completed -= _chooserTaskHandler;
    	//set handler action
        _chooserTaskHandler += (o, result) => UpdateText(PersonNo1, result);
    	//re-attach handler
    	phNumChoseTask.Completed += _chooserTaskHandler;
        phNumChoseTask.Show();
    }
    
    private void Button1_Click(object sender, RoutedEventArgs e)
    {
    	phNumChoseTask.Completed -= _chooserTaskHandler;
        _chooserTaskHandler += (o, result) => UpdateText(PersonNo2, result);
    	phNumChoseTask.Completed += _chooserTaskHandler;
        phNumChoseTask.Show();
    }
    
    private void UpdateText(TextBox textBox, PhoneNumberResult result)
    {
        if (result.TaskResult == TaskResult.OK)
            textBox.Text = result.PhoneNumber;
    }
