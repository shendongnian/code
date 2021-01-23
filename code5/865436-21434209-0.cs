    Func<Action, Task> doAsync = async (action) =>
    {
        await Task.Yield();
        action();
    };
    var messageBoxTask = doAsync(() => 
        MessageBox.Show("Hello!"));
    await Task.Delay(1000);
    SendKeys.Send("{ENTER}")
    await messageBoxTask;
    Debug.Print("continue after a message box");
