    DateTime? CallBack = null;
    string callBackDate = modelValue.Field<string>("CallBack");
    if(!string.IsNullOrWhiteSpace(callBackDate))
    {
        DateTime cdate;
        if(DateTime.TryParse(callBackDate, out cdate))
            CallBack = cdate;
    }
