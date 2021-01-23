    private void buttonGo_Click(object sender, EventArgs e)
    {
        // Variables
        int startYr = 0;
        int endYr = 0;
        bool checkForCensus = checkBoxCensus.Checked;
        bool checkForElection = checkBoxElection.Checked;
        // Input Validation
        if (!int.TryParse(textBoxStartYr.Text, out startYr))
        {
            MessageBox.Show("Please enter a four digit year");
            return;
        }
        if (!int.TryParse(textBoxEndYr.Text, out endYr))
        {
            MessageBox.Show("Please enter a four digit year");
            return;
        }
        // Loop
        for (int yearDisp = startYr; yearDisp <= endYr; yearDisp++)
        {
            bool isCensusYear, isElectionYear;
            if (checkForCensus && (yearDisp % 10) == 0)
                isCensusYear = true;
            if (checkForElection && (yearDisp % 4) == 0)
                isElectionYear = true;
            listBoxDisp.Items.Add(String.Format("{0}: {1}{2}{3}",
                yearDisp.ToString(),
                isCensusYear ? "this is a census year" : "",
                (isCensusYear && isElectionYear) ? "," : "",
                isElectionYear ? "this is an election year" : ""
            ));
        }
    }
