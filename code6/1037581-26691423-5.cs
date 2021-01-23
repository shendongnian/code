    private void ActualLog(string input)
    {
        var currentForm = form as Main;
        if (!this.IsHandleCreated)
        {
            this.CreateHandle();
        }
        if (currentForm.txtServerLog.InvokeRequired)
        {
            this.Invoke(new Action<string>(UpdateTextBox), new object[] { input }); //Make sure to use Invoke, not BeginInvoke
            return;
        }
        UpdateTextBox(input);
    }
