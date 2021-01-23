    public async Task MethodA(int param)
    {
        for (int i = 0; i < param; i++)
        {
            await Task.Run(() => InsertDataIntoDatabase(i));
            statusTextBox.Text = "insert #" + i + " done";
        }
    }
