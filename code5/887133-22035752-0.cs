    public string[] getHeaderValue(string key, Request Request) {
        for (int i = 0; i < Request.Headers.Count; i++)
        {
            if (Request.Headers.GetKey(i) == key)
            {
                return Request.Headers.GetValues(i);
            }
        }
        return null; //here you should throw an error because the key was not found
    }
