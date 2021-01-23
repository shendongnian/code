    private Random rnd = new Random();
    private int lastSelectedIndex = -1;
        
    void RandomRecord()
    {
        int noRows = dataset.Tables[0].Rows.Count;
        int index = rnd.Next(noRows);
        while(index == lastSelectedIndex && noRows > 1) {
            index = rnd.Next(noRows);
        }
        lastSelectedIndex = index;
        TxtDisplayQuestion.Text = dataset.Tables[0].Rows[index][Emp_Title].ToString();
    }
