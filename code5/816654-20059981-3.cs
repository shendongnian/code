        Dictionary<int, Team> dictionary = new Dictionary<int, Team>();
        int teamNum = 1;
        // Add your Teams to a dictionary (example)
        dictionary.Add(teamNum ,new Team(teamNum++));
        dictionary.Add(teamNum, new Team(teamNum++));
        dictionary.Add(teamNum, new Team(teamNum++));
        // Populate a comboBox
        foreach(KeyValuePair<int,Team> kvp in dictionary)
        {
            comboBox1.Items.Add(kvp.Value.getTeamNum().ToString());
        }
        // get a team for a given teamNumer
        int targetTeamNumber = 2;
        if (dictionary.ContainsKey(targetTeamNumber))
        {
            Team team = dictionary[targetTeamNumber];
            // do something with the team
        }
