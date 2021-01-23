    int i = -1;
    string user_id = string.Empty;
    if (!int.TryParse(reini, out i))
    {
        user_id = reini;
    }
    if (!String.IsNullOrEmpty(user_id)) // it is an alphanumeric
    {
    }
    else // it is an integer, use i
    {
    }
