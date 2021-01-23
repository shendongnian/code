    //In parent form ...
    private MyProgressBarForm progressBarForm = new MyProgressBarForm();
    private void button1_Click(object sender, EventArgs e)
    {
        progressBarForm.Show();
        Task task = new Task(RunComparisons);
        task.Start();
    }
    private void RunComparisons()
    {
        for (int i = 1; i < 100; i++)
        {
            System.Threading.Thread.Sleep(50);
            progressBarForm.UpdateProgressBar(1, i);
        }
    }
    //In MyProgressBarForm ...
    public void UpdateProgressBar(int index, int value)
    {
        this.Invoke((MethodInvoker) delegate{
            if (index == 1)
            {
                progressBar1.Value = value;
            }
            else
            {
                progressBar2.Value = value;
            }
        });
    }
