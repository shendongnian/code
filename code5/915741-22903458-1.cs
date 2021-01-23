    private int phaseOne()
    {
        int phaseOneResult = 0;
        try
        {
            
            //Update query here
            //...
            //...
            if(cmdUpdatePhaseOne.ExecuteNonQuery() > 0) 
            {
                phaseOneResult = 1;
            }
        }
        catch (Exception ex)
        {
            lblPhaseOneErr.Text = "Error submitting: " + ex.Message;
        }
        finally
        {
            connection.Close();
        }
    
        return phaseOneResult;
    }
