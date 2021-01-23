    DateTime OutputTime = new DateTime();
    if(DateTime.TryParse(dr["column_name"].ToString(),out OutputTime))
    {
     ///manipulate output datetime here if successful
    }
    else
    {
    ///figure out why the conversion failed / handle error
    }
