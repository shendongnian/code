     public void GetDownLoads(object sender, ServiceReference1.GetDownloadsCompletedEventArgs e)
    {
        try
        {
            downoladedList = e.Result.ToList<string>();
            foreach (var elem in downoladedList)
            {
            string[] elemProp = new string[8];
            elemProp = elem.Split('=');
            if (elemProp[3] == "1")
                elemProp[3] = "downloaded";
            else
                elemProp[3] = "in progress";
            DataCollection.Add(new Downloaded(elemProp[1], elemProp[3], "test.png"));
            }
        }
        catch (Exception ee)
        {
        }
    }
