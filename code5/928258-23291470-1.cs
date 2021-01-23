    private void btnTestCommand_Tap(object sender, GestureEventArgs e)
    {
        Button btn=sender as Button;
        var command = btn.Command;
        if(command !=null)
        {
            MessageBox.Show("Command is not null");
            if(command is ReactiveAsyncCommand)
            {
                MessageBox.Show("Command is of ReactiveAsyncCommand type");
            }
        }
    }
