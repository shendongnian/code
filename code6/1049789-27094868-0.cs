    private void button1_Click(object sender, EventArgs e)
    {
        using (Form form = MyWaitMessageForm())
        {
            form.Shown += async (sender1, e1) =>
            {
                await Task.Run(() => MyLongRunningWork());
                form.Close();
            }
            form.ShowDialog(this);
        }
    }
