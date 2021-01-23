    private static Dictionary<HttpStatusCode, String> Views
    {
        get
        {
            // when the private field is null, initialize the value
            if (_views == null)
            {
                _views = new Dictionary<HttpStatusCode, String> {
                        { HttpStatusCode.NotFound, "NotFound_" },
                        { HttpStatusCode.InternalServerError, "Internal_" } };
            }
            // and always return the private field
            return _views;
        } 
    }
