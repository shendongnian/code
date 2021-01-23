    public delegate bool ParseLine(string line);
    // Global dictionary where you store the strings as key 
    // and the ParseLine as the delegate to execute
    Dictionary<String, ParseLine> m_Actions = new Dictionary<String, ParseLine>() ;
    
    void Main()
    {
        // Initialize the dictionary with the delegate corresponding to the strings keys
        m_Actions.Add("MODE", new ParseLine(Task1));
        m_Actions.Add("TIME_YEAR", new ParseLine(Task2));
        m_Actions.Add("TIME_MONTH", new ParseLine(Task3));
        m_Actions.Add("TIME_DAY", new ParseLine(Task4));
        .....
        while ((line = reader.ReadLine()) != null) 
        {
            string command = line.Substring(0, line.IndexOf(','))
            m_Actions[command](line);
        }
    }
    
    void Task1(string line)
    {
        // this will handle the MODE line
        GlobalData.Mode = Convert.ToInt32(line.Remove(0, "MODE".Length));
       
    }
    void Task2(string line)
    {
         GlobalData.time_year = Convert.ToInt32(line.Remove(0, "TIME_YEAR".Length));
    }
    void Task3(string line)
    {
        .....
    }
    void Task4(string line)
    {
        .....
    }
