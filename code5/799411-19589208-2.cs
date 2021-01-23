    // The common signature for every methods stored in the value part of the dictionary
    public delegate void ParseLine(string line);
    // Global dictionary where you store the strings as keyword
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
            // Search the space that divide the keyword from the value on the same line
            string command = line.Substring(0, line.IndexOf(' ')).Trim();
            // a bit of error checking here is required
            if(m_Actions.ContainsKey(command))
                m_Actions[command](line);
            
        }
    }
    
    void Task1(string line)
    {
        // this will handle the MODE line
        GlobalData.Mode = Convert.ToInt32(line.Substring(line.IndexOf(' ')+1).Trim());
       
    }
    void Task2(string line)
    {
         GlobalData.time_year = Convert.ToInt32(line.Substring(line.IndexOf(' ')+1).Trim());
    }
    void Task3(string line)
    {
        .....
    }
    void Task4(string line)
    {
        .....
    }
