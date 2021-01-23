    public async void OnButtonClickDoDbOperations()
    {
        await Task.Run(async () =>
        {
             // Your DB operations goes here
        });
        // Any work on the UI should go on the UI thread
        // WPF
        await Application.Current.Dispatcher.InvokeAsync(() => {
             // UI updates
        });
        // WinForms
        // To do work on the UI thread we need to call invoke on a control
        // created on the UI thread..
        // "this" is the Form instance
        this.Invoke(new Action(() =>
        {
            button1.Text = "Done";
        }));
    }
