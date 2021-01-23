    try
    {
        //Your code here
    }
    catch (SqlCeException e)
    {
        foreach (SqlCeError error in e.Errors)
        {
            //Error handling, etc.
            MessageBox.Show(error.Message);
        }
    }
