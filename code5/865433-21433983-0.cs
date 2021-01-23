    Task DelayTask() {
        return Task.Delay(1000);
    }
    await DelayTask();
    SendKeys.Send("{ENTER}");
    MessageBox.Show("Hello!");
    Debug.Print("continue after a message box");
