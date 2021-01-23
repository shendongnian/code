    public object Get(string id)
    {
        // do some SQL querying here to grab the model or what have you.
    
        if (somethingGoesWrong = true)
        return new {result = "fail"}
        else
        return new {result = "success", value= "some value goes here"}
    }
