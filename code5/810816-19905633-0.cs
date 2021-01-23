     protected void BookNow_Click(object sender, EventArgs e)
            {
                //Session["Date"]=ddlDate.SelectedItem+ ddlMonth.SelectedItem+ddlYear.SelectedItem;
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                conn.Open();
                
                //string date = ddlYear.SelectedValue.ToString() + "/" + ddlMonth.SelectedValue.ToString() + "/" + ddlDate.SelectedValue.ToString();
                int year = Convert.ToInt32(ddlYear.SelectedValue.ToString());
                int month = Convert.ToInt32(ddlMonth.SelectedValue.ToString());
                int day = Convert.ToInt32(ddlDate.SelectedValue.ToString());
                DateTime date = new DateTime(year, month, day);
    
                SqlCommand cmd = new SqlCommand(@"insert into OnlineBookingEvent(BookingEvent,BookeventDate,cdt,udt)values 
                                 (@BookingEvent,@BookeventDate,@cdt,@udt)", conn);
                cmd.Parameters.AddWithValue("@BookingEvent", ddlEventName.SelectedItem);
                cmd.Parameters.AddWithValue("@BookeventDate", date);
                cmd.Parameters.AddWithValue("@cdt", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@udt", System.DateTime.Now);
                cmd.ExecuteNonQuery();
            }
