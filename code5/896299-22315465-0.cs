    private void compareList()
        {
            StreamReader champFile = File.OpenText("WorldSeries.txt");
            Dictionary<string, int> champList = new Dictionary<string, int>();
            string selectedTeam;
            string currentChamp;
            while (!champFile.EndOfStream)
            {
                currentChamp = champFile.ReadLine();
                if(champList.containsKey(currentChamp))
                    champList.get(currentChamp) += 1;
                else
                    champList.Add(champFile.ReadLine(), 1);
            }
            while (teamList.SelectedIndex != 0)
            {
                selectedTeam = teamList.SelectedItem.ToString();
            }
            if (champList.hasKey(selectedTeam))
            {
                MessageBox.Show("The " + selectedTeam + "has won the World Series " + champList.get(selectedTeam) + "times! ")
            }
            else
            {
                MessageBox.Show("The " + selectedTeam + "has never won the World Series.")
            }
        } 
