        for (yearDisp = startYr; yearDisp <= endYr; yearDisp++)
        {
            bool isElection = (0 == (yearDisp % 4)) && checkBoxCensus.Checked;
            bool isCensus   = 0 == (yearDisp % 10) && checkBoxElection.Checked;
            string text = yearDisp.ToString();
            if (isCensus && isElection)
            {
                text += " This is a both a census year and an election year";
            }
            else if (isCensus)
            {
                text += " This is a census year", yearDisp;
            }
            else if (isElection)
            {
                text += " This is an election year";
            }
            listBoxDisp.Items.Add(text);
        }
