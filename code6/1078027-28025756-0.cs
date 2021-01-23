    if (timeDiff.TotalSeconds < 60.0)
    {
        //Here with green color
        dataCell.ForeColor = System.Drawing.Color.Green;
        dataCell.Text += o.name;
        //I tried dataCell.Text += string.Format("<p //style=\"color":green\" src='{0}'>", o.name); but doesn't work. 
    }
    else
    {
        //Here with red color
        dataCell.ForeColor = System.Drawing.Color.red;
        dataCell.Text += o.name;
    }
