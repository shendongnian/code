    private void buttonGo_Click(object sender, EventArgs e)
    {
        //Variables
        int startYr = 0;
        int endYr = 0;
        int yearDisp = 0;
        //Input Validation
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
        //Loop
        for (yearDisp = startYr; yearDisp <= endYr; yearDisp++)
        {
            bool isElection = 0 == (yearDisp % 4);
            bool isCensus   = 9 == (yearDisp % 10); // Year ending in 9
            if (isCensus && checkBoxCensus.Checked)
            {
                listBoxDisp.Items.Add(String.Format("{0} This is a census year", yearDisp));
            }
            else if (isElection && checkBoxElection.Checked)
            {
                listBoxDisp.Items.Add(String.Format("{0} This is an election year", yearDisp));
            }
            else {
                listBoxDisp.Items.Add(yearDisp.ToString());
            }
        }       
    }
