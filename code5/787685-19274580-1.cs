    private static Task<bool> WaitTillUserInput()
    {
        TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
        uiSynchronizationContext.Post(x =>
        {
            if (MessageBox.Show("Do you want to rollback...?", "Please confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                tcs.SetResult(true);
            }
            else
            {
                tcs.SetResult(false);
            }
        }, null);
        return tcs.Task;
    }
