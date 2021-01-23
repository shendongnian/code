    private void createTimeLine()
    {
        for (int x = 0; x < (startStage+ midStage+ endStage); x++)
        {
            AllDays[x] = new DataGridViewColumn();
            AllDays[x].CellTemplate = new DataGridViewTextBoxCell(); // for TextBox
            timeLine.Columns.Add(AllDays[x]);
        }
    }
