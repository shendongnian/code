    for (yearDisp = startYr; yearDisp <= endYr; yearDisp++)
    {
        int index = listBoxDisp.Items.Add("Year:" + yearDisp.ToString());
        if (checkBoxCensus.Checked == true)
        {
            if ((yearDisp % 10) == 0)
            {
                listBoxDisp.Items[index] += ",This is a census year";
            }
            else { }
        }
        else
        {
            //nothing needed
        }
        if (checkBoxElection.Checked == true)
        {
            if ((yearDisp % 4) == 0)
            {
                listBoxDisp.Items[index] += ",This is an election year";
            }
            else { }
        }
        else
        {
            //nothing
        }
    }   
