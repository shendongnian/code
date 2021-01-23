    public string method(int projectid)
    {
        string result = string.empty;
        var service = _service;
        //{
             result = service.dosomething(); //_service implements it's own Dispose
        //}
    
        result += "we are going to do some further operations like sum a large list that"
        result += "might take a non-trivial amount of time."
    
        return result;
    }
