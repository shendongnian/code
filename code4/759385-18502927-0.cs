    private void button1_Click(object sender, EventArgs e)
    {
        var deleteFooTask = DeleteFooAsync();
        deleteFooTask.ContinueWith(ErrorHandeler, TaskContinuationOptions.OnlyOnFaulted);
    }
    private void ErrorHandeler(Task obj)
    {
        MessageBox.Show(String.Format("Exception happened in the background of DeleteFooAsync.\n{0}", obj.Exception));
    }
    public async Task DeleteFooAsync()
    {
        await Task.Delay(5000);
        throw new Exception("Oops");
    }
