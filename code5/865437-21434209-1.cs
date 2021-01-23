    Func<Action, Task> doAsync = async (action) =>
    {
        await Task.Yield();
        action();
    };
    var messageBoxTask = doAsync(() => 
        MessageBox.Show("Hello!"));
    var delay = Task.Delay(1000);
    var task = await Task.WhenAny(delay, messageBoxTask);
    if (task != messageBoxTask)
    {
        SendKeys.Send("{ENTER}")
        await messageBoxTask;
    }
    Debug.Print("continue after a message box");
