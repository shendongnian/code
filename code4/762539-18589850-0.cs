    while (true)
    {
        try
        {
              //Code
        }
        catch (Exception ex)
        {
            if (ex.Message.Substring(1, 5) == "error")
            {
                continue;
                //goto bottom; //This doesn't makes sense after we transfer control 
            }
            else
            {
                 break;//Did you mean this?
            }
         }
    }
