    public void SendToBack(Series s)
    {
        if (myChart1.Series.Contains(s))
        {
            myChart1.Series.Remove(s);
            myChart1.Series.Insert(0, s);
        }
    }
