    private void SomeWork()
    {
        for (var i = 0; i <3504 ; i++)
            for (var j = 0; j < 2306; j++)
                {
                 ........
                }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        using (MessageWaitForm form = new MessageWaitForm())
        {
            form.Shown += async (sender1, e1) =>
            {
                await Task.Run(() => SomeWork());
                form.Close();
            }
            form.ShowDialog();
        }
    }
