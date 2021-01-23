    DayOfWeek comptag = e.Day.Date.DayOfWeek;
    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
    {
        string thisday = e.Day.Date.ToString();
        string dayfromdb = ds2.Tables[0].Rows[i]["Date"].ToString();
        list.Add(dayfromdb);
        if (comptag != DayOfWeek.Saturday && comptag != DayOfWeek.Sunday && e.Day.IsOtherMonth == false && dayfromdb == thisday)
        {
            e.Cell.Controls.Add(auswahlliste2);
        }
        else if (comptag != DayOfWeek.Saturday && comptag != DayOfWeek.Sunday && e.Day.IsOtherMonth == false && liste.Contains(thisday)==false)
        {
            e.Cell.Controls.Add(auswahlliste);
        }
    } // Ende for
