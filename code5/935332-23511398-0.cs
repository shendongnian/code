    process.Exited += (@Sender, args) =>
    {
        tcs.SetResult(process);
        System.Windows.MessageBox.Show("Done");
        process.Dispose();
    };
    process.WaitForExit();
