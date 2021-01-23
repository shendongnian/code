    try
    {
        //your work
    }
    catch (System.IO.EndOfStreamException ex)
    {
        System.Diagnostics.Debug.WriteLine("Stream exception caught: " + ex.Message.ToString());
                                
                            
    }
    finally
    {
        if(myConnection != null)
        {
            myConnection.Close();
            myConnection.Dispose();
        }
    }
