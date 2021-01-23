    private void buttonX1_Click(object sender, EventArgs e)
    {
        i = 0;
        labelX1.Text = "";
        InitializeBackgoundWorkers();
        for (int a = 0; a < numOfTheards; a++)
        {
            if (threadArray[a].IsBusy)
            {
                threadArray[a].CancelAsync();
            }
            else
            {
                progressBarX1.Value = progressBarX1.Minimum;
                threadArray[a].RunWorkerAsync();
            }
        }
    }
