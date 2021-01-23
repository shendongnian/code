    if(!String.IsNullOrEmpty(reader.GetByte(16).ToString()))
    {
    if (reader.GetByte(16) == 10)
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
    }
