            start = Team.IndexOf("TeamID", start) + 8;
            int end = Team.IndexOf(",", start); //start index correct
            //teamsListBox.Items.Add(end);
            int id = Convert.ToInt32(Team.Substring(start, end - start)); //throws FormatException for string to DateTime
            //String id = Team.Substring(start, (end - start));
            //teamsListBox.Items.Add("id is " + id);
            start = Team.IndexOf("TeamName", start) + 11;
            end = Team.IndexOf("\"", start);
            //teamsListBox.Items.Add(end);
            String name = Team.Substring(start, (end - start));
            //teamsListBox.Items.Add("name is " + name);
            start = Team.IndexOf("TeamCity", start) + 11;
            end = Team.IndexOf("\"", start);
            String city = Team.Substring(start, (end - start));
