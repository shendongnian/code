    protected void StoreDynamicControls()
    {
        con.Open();
        using (SqlCommand cmd2 = new SqlCommand("insert into EventSlots(EventDayId,SlotStartTime,SlotAvailable) values(@EventDayId,@SlotStartTime,@SlotAvailable)", con))
        {
            foreach (Control ctl in Timediv.Controls)
            {  
              CheckBox cbx = (CheckBox) e.FindControl("myCheckBox");
              Label lbl = (Label) e.FindControl("myLabel");
              ... /* rest of you code */
        }
    }
