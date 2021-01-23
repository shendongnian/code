    //just some objects for me to play with
    var requests =  Enumerable.Range(1).Select(i => new { Time = DateTime.Now, Method = "blah" }).ToList();
    var responses =  Enumerable.Range(1).Select(i => new { Time = DateTime.Now, Method = "blah" }).ToList();
    
    foreach (var req in requests)
    {
        //In all of the responses - find the one that happened soonest after the request (with the same method name)
        var closestResponse = responses
            .Where(resp => resp.Method == req.Method)
            .OrderBy(resp => resp.Time - req.Time)
            .FirstOrDefault();
    
        //No more responses - exit
        if(closestResponse == null)
            break;
        responses.Remove(closestResponse);
    
        //make new call pair, with the closest rseponse
    }
