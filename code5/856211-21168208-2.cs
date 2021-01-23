    private async void button1_Click(object sender, EventArgs e)
    {
            int numOfTasks = 8;
            progressBar1.Maximum = numOfTasks;
            progressBar1.Minimum = 0;
            try
            {
                for (int i = 0; i < numOfTasks; i++)
                {
                    await Task.Run(() => DoWork(i));
                    UpdateBar();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString(), "AAAAAARGH");
            }
        }
