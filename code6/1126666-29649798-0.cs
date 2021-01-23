    private void GetActivity()
    {
        try
        {
            CON = new OracleConnection(Connection);
            CON.Open();
            OracleCommand COMMAND1 = new OracleCommand("Select ACTIVITYID,to_char(ACTIVITYDATE,'DD-MON-YYYY') as ACTIVITYDATE,TITLE,STARTTIME,ENDTIME,ACTIVITYTIME as TIMETAKEN from DAILY_ACTIVITIES1 where ACTIVITYDATE= (Select min(ACTIVITYDATE) from DAILY_ACTIVITIES1)", CON);
            OracleDataReader READER = COMMAND1.ExecuteReader();
            int count = READER.FieldCount;
            if (READER.HasRows)
            {
                int i = 1;
                TextBox txtDate;
                TextBox txtDA;
                ContentPlaceHolder cph = (ContentPlaceHolder)this.Master.FindControl("MainContent");
                while (READER.Read() && i <= 6)
                {
                    if (i == 1)
                    {
                        txtDate = (TextBox)cph.FindControl(string.Format("Date{0}TextBox", i.ToString()));
                        txtDate.Text = READER[1].ToString();
                        txtDate.Enabled = false;
                    }
                    txtDA = (TextBox)cph.FindControl(string.Format("D1A{0}TextBox", i.ToString()));
                    if (txtDA.Text == "")
                    {
                        txtDA.Text = "Title:" + READER[2].ToString() + "\n";
                        txtDA.Text += "Start-time:" + READER[3].ToString() + "\n";
                        txtDA.Text += "End-time:" + READER[4].ToString() + "\n";
                        txtDA.Text += "Timetaken:" + READER[5].ToString() + "\n";
                    }
                    txtDA.Enabled = false;
                    i++;
                }
            }
            CON.Close();
        }
        catch (Exception et)
        {
            et.ToString();
        }
    }
