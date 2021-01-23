        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@VisitorNo", "Here Value for the Number in current question it is not specify from where to take it. Probably this is int or guid you should have a way to set next int or new guid");
            cmd.Parameters.AddWithValue("@Name", VisitorName.Text);
            cmd.Parameters.AddWithValue("@NRIC", NRIC.Text);
            cmd.Parameters.AddWithValue("@Reason", ReasonVisit.Text);
            cmd.Parameters.AddWithValue("@CardID", CardID.Text);
            cmd.Parameters.AddWithValue("@CardPin", CardPin.Text);
            
            cmd.ExecuteNonQuery();
        }
        catch (Exception err)
        {
            //do something with the exception !
        }
        finally
        {
            conn.Close();
        }
                  
