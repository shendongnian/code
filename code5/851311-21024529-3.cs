    private void buttonX1_Click(object sender, EventArgs e)
    {
        i = 0;
        labelX1.Text = "";
        InitializeBackgoundWorkers();
        progressBarX1.Value = progressBarX1.Minimum;
        for (int a = 0; a < numOfTheards; a++)
        {
            string itemData = lst[a];
            threadArray[a].RunWorkerAsync(itemData);
        }
    }
    
