    private void button1_Click(object sender, EventArgs e)
    {
        EndlessTask();
    }
    async Task EndlessTask()
    {
        for(int i = 0; true; i++)
        {
            textBox1.Text = i.ToString();
            await Task.Delay(500);
        }
    }
