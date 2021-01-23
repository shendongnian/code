    DateTime _startedRealEstate = new DateTime(2012, 11, 15);
    public DateTime StartedRealEstate { get { return _startedRealEstate; } set { _startedRealEstate = value; } }
    public int YearsAsAgent
    {
      get
      {
          DateTime zeroTime = new DateTime(1, 1, 1);
          TimeSpan span = DateTime.Now - StartedRealEstate;
          int years = (zeroTime + span).Year - 1;
          return years;
      }
     }
        
     private void button1_Click_2(object sender, EventArgs e)
     {
          int totalYears = YearsAsAgent;
     }
