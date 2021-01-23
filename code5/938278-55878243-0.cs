    public string DateConvertion(string Input)
    {
        var date = DateTime.ParseExact(Input, "dd/M/yyyy hh:mm:ss tt", 
                                        CultureInfo.InvariantCulture);
          
        return date.ToString("yyyy-MM-dd");            
    }
