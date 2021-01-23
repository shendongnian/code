    public DateTime? MyDateTime
    {
        get 
        { 
            if (_myDateTime == null) return null;
            return _myDateTime.Value.Date; 
        }
    }
    private DateTime? _myDateTime;
