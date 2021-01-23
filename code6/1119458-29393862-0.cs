    //Check to see if the Unique_ID is 10 or 11 and process accordingly
    //10 = Both boxes, 11 = Rework only
    if (reader.IsDBNull(16))
    {
       //Add here your code to handle null value
    }
    else if (reader.GetByte(16) == 10)
    {
       int ES = Convert.ToInt32(reader["ESCALATED"]);
       if (ES == 0)
       {
          chkEscalated.Checked = false;
       }
       else
       {
          chkEscalated.Checked = true;
          chkEscalated.Visible = true;
          lblEscalated.Visible = true;
          chkRework.Visible = true;
          lblRework.Visible = true;
        }
    }
    else if (reader.GetByte(16) == 11)
    {
    }
    else
    {
    }
