    public static ReactiveCommand<object> CreateAndSubscribe() 
    {
        var displayCommand = ReactiveCommand.Create();
        displayCommand.Subscribe(_ =>
        {
            MessageBox.Show("Button clicked.");
        });
        return displayCommand;
    }
