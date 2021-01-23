    //first, set up the toys index by accepting some inputs
    string[,] toys = new string[5, 4];
    for (int week = 0; week <= 3; week++)
    {
        for (int day = 0; day <= 4; day++)
        {
            toys[day, week] = Microsoft.VisualBasic.Interaction.InputBox("Please enter value for Day " + Convert.ToString(day + 1) + " in week " + Convert.ToString(week + 1) + ".");
        }
    }
    
    //then, print the output line by line by looping through the toys array
    //the first line must be separate because the headings are not part of the array
    txtOutput.Text += "Mon" + "\t" + "Tue" + "\t" + "Wed" + "\t" + "Thu" + "\t" + "Fri" + "\t" + "\r\n";
    for (int week = 0; week <= 3; week++)//foreach week
    {
        //construct the line of text which represents the week's data
        txtOutput.Text += "Week " + week+1 + "\t";
        for (int day = 0; day <= 4; day++)
        {
           txtOutput.Text += toys[day,week];
           if(day != 4)
           {
             //so long as it is not the last day, then you have to tab over
             txtOutput.Text += "\t";
           }
        }
        //wrap things up by moving to the next line before you iterate to the next line
        txtOutput.Text += "\r\n";
     }
        
    
