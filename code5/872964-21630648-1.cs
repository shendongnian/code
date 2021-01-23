    public MainPage()
    {
    	InitializeComponent();
    	phNumChoseTask = new PhoneNumberChooserTask();
    	//set default handler
    	_chooserTaskHandler = (o, result) => UpdateText(Person1, result);
    	phNumChoseTask.Completed += _chooserTaskHandler;
    }
    
    private Action<TextBox, PhoneNumberResult> _chooserTaskHandler;
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        _chooserTaskHandler = (o, result) => UpdateText(PersonNo1, result);
        phNumChoseTask.Show();
    }
    
    private void Button1_Click(object sender, RoutedEventArgs e)
    {
        _chooserTaskHandler = (o, result) => UpdateText(PersonNo2, result);
        phNumChoseTask.Show();
    }
    
    private void UpdateText(TextBox textBox, PhoneNumberResult result)
    {
        if (result.TaskResult == TaskResult.OK)
            textBox.Text = result.PhoneNumber;
    }
