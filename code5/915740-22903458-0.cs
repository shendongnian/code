    private int phaseOne()
    {
        int phaseOneResult = 1;
        try
        {
            
            //Update query here
            //...
            //...
            cmdUpdatePhaseOne.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            lblPhaseOneErr.Text = "Error submitting: " + ex.Message;
            phaseOneResult = 0;
        }
        finally
        {
            connection.Close();
        }
    
        return phaseOneResult;
    }
