    JsonSerializer serializer = new JsonSerializer { NullValueHandling = NullValueHandling.Ignore };
    private string _property1;
    public string Property1 
    { 
        get 
        {
            if(getcurrentuser.isauthorizedforproperty1)
            {
                return _property1;
            }
            else 
            {
                return null;
            }
        }
        set
        {
            _property1 = value;
        }
    }
