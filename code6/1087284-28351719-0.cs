        List<PaceCalculator> TimeList = new List<PaceCalculator>();
        List<PaceCalculator> Distancelist = new List<PaceCalculator>();
        while (Reader.Read())
        {
            pace = new PaceCalculator();
            pace.Distance = (int)Reader["EventDistance"];
            pace.Time = (string)Reader["EventTime"];
            Distancelist.Add(pace);
            TimeList.Add(pace);
        }
        listBox1.DisplayMember = "Distance";
        listBox1.DataSource = Distancelist;
        listBox2.DisplayMember = "Time";
        listBox2.DataSource = TimeList;
