    public bool CheckValid(string str)
    {
        TimeSpan temp;
        return str.Split(new[] { ',', '#' })
                          .All(r => TimeSpan.TryParseExact
                                                         (r, 
                                                          @"hh\:mm", 
                                                          CultureInfo.InvariantCulture, 
                                                          out temp));
    }
