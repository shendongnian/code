    char StatusCode;
    if (AutoFFSuccess)
    {
        if (ActSuccess)
            StatusCode = 'P';
        else
            StatusCode = 'W';
    }
    else if (FUPSuccess)
    {
        if (ActSuccess)
            StatusCode = 'F';
        else
            StatusCode = 'G';
    }
    else
        StatusCode = 'E';
