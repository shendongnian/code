    MessageBoxManager manager = new MessageBoxManager();
    manager.ShowTitleCountDown = true;
    manager.AutoCloseResult = System.Windows.Forms.DialogResult.No;
    manager.TimeOut = 5;
    manager.AutoClose = true;
    manager.HookEnabled = true;
    DialogResult res = MessageBox.Show("Testing", "Hello", MessageBoxButtons.YesNo);
    
    if (res == System.Windows.Forms.DialogResult.Yes)
    {
        Console.WriteLine("yes pressed");
    }
    else
    {
        Console.WriteLine("no presssd");
    }
