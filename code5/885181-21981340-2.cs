    using (SathsurEntities se = new SathsurEntities())
    {    
        tbl_Events user = new tbl_Events();   
    
        user.Event_name = txtEventName.Text;
        user.Event_date = Convert.ToDateTime(txtEventDate.Text);    
        user.Image_url = lblimg.Text;    
        user.Is_free_entry = rblEntry.SelectedValue.ToBoolean();    
        user.Booking_url = txtBooking.Text;
    
        se.AddTotbl_Events(user);
    
        se.SaveChanges();
    
        Response.Write("Event Added Successfuly!");    
    }
