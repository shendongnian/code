    bool foundException = false;
    Try
    {
        // Reset the variable in the first Try
        foundException = false;
    }
    Catch(Exception)
    {
        foundException = true;
    }
    End Try
    
    Try
    {
        if(foundException)
        {
            break;
        }
    }
    Catch(Exception)
    {
    
    }
