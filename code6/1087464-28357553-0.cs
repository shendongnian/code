    TaskCompletionSource<string> resultTcs = new TaskCompletionSource<string>();
    private async Task<string> SendCommandAsync(string command)
    {
        serialPort1.Write(command);  // send the command
        var timeout = Task.Delay(500);
        //Wait for either the task to finish or the timeout to happen.
        var result = await Task.WhenAny(resultTcs.Task, timeout).ConfigureAwait(false);
        //Was the first task that finished the timeout task.
        if (result == timeout)
        {
            throw new TimeoutException(); //Or whatever you want done on timeout.
        }
        else
        {
            //This await is "free" because the task is already complete. 
            //We could have done ((Task<string>)result).Result but I 
            //don't like to use .Result in async code even if I know I won't block.
            return await (Task<string>)result;
        }
    }
    private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        var response = serialPort1.ReadExisting();
        tcs.SetResult(response);
        //reset the task completion source for another call.
        resultTcs = new TaskCompletionSource<string>();
    }
