    char statusCode;
    if (AutoFFSuccess)
    {
        if (ActSuccess)
        {
            statusCode = 'P';
        }
        else
        {
            statusCode = 'W';
        }
    }
    else
    {
        if (FUPSuccess)
        {
            if (ActSuccess)
            {
                statusCode = 'F';
            }
            else
            {
                statusCode = 'G';
            }
        }
        else
        {
            statusCode = 'E';
        }
    }
