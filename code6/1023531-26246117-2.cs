    private void createTimeLine()
    {
        for (int x = 0; x < (startStage+ midStage+ endStage); x++)
        {
            AllDays[x] = new DataGridViewTextBoxColumn();
            timeLine.Columns.Add(AllDays[x]);
        }
    }
