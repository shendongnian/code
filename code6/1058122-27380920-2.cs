    public static NmeaMessage TryParseNmeaMessage(TInputData d)
    {
        if (IsValidInput(d))
            return new NmeaMessage(d);
        else
            return null;
    }
  
