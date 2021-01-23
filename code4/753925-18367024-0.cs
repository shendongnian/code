    public void InsertLineBreaks(List<LineChart> inputList, int sampleInterval)
    {
        List<LineChart> breaklinesList = new List<LineChart> { };
        for (int i = 1; i <= inputList.Count; i++)
        {
            if ((inputList[i].X - inputList[i - 1].X).TotalMinutes > sampleInterval)
            {
                LineChart breakline = inputList[i];
                breakline.BreakLine = 1;
                breaklinesList.Add(breakline);
            }
           
        }
     inputList.AddRange(breaklinesList);
    }
