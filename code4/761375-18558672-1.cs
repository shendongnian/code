    public void getEventTime(string filePath, string currDate, string currentDateTimeHM)
    {
        Form NotificationForm = new Notification();
        //reading the *.csv file and convert to the array of data
        FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs);
        //create array for getting any vlaue from string
        string[] arrOfData = sr.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        sr.Close();
        List<string> lines = new List<string>();
        bool status=false;//variable for showing form if event exist
        foreach (var l in arrOfData)
        {
            if (l.Contains(currDate) && l.Contains(currentDateTimeHM))
            {
                string[] temp = l.Split(',').Take(5).ToArray();
                NotificationForm.NotText = temp[1].ToString();
                status = true;
            }
        }
        if (status)
        {
            //show Notification Form
            
            NotificationForm.Visible = true;
        }
    }
