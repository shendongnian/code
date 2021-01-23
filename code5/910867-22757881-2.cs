    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UpdateLabels();// code moved to a method
        }
    }
    protected void txtSubmit_Click(object sender, System.EventArgs e)
    {
    
      // at the end of your code 
      txtEventType.Text = string.Empty;
      txtEventName.Text = string.Empty;
      // set all the text boxes empty like above
      // update the label values 
      UpdateLabels();
    }
    public void UpdateLabels()
    {
        string strConnString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ConnectionString;
        string str;
        SqlCommand com;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        str = "select * from EVENT_ANNOUNCE where getdate() >= STARTDATE and cast(getdate() as Date) <= ENDDATE";
        com = new SqlCommand(str, con);
        SqlDataReader reader = com.ExecuteReader();
        var events = new List<string>();
        if (reader.HasRows)
        {
            while (reader.Read())
                events.Add(reader["EVENTNAME"].ToString());
        }
        if (events.Count >= 1)
            lblEvent1.Text = events[0];
        if (events.Count >= 2)
            lblEvent2.Text = events[1];
        if (events.Count >= 3)
            lblEvent3.Text = events[2];
        reader.Close();
        con.Close();
    }
