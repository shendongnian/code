    string[,] toys = new string[5, 4];
    for (int week = 0; week <= 3; week++)
    {
        for (int day = 0; day <= 4; day++)
        {
            toys[day, week] = Microsoft.VisualBasic.Interaction.InputBox("Please enter value for Day " + Convert.ToString(day + 1) + " in week " + Convert.ToString(week + 1) + ".");
        }
    }
    
    txtOutput.Text += "Mon" + "\t" + "Tue" + "\t" + "Wed" + "\t" + "Thu" + "\t" + "Fri" + "\t" + "\r\n";
    for (int week = 0; week <= 3; week++)
    {
        txtOutput.Text += "Week " + week+1 + "\t";
        for (int day = 0; day <= 4; day++)
        {
           txtOutput.Text += toys[day,week];
           if(day != 4)
           {
             txtOutput.Text += "\t";
           }
        }
        txtOutput.Text += "\r\n";
     }
        
    
