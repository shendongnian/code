    public ActionResult RobotsText() {
        Response.ContentType = "application/json";
        
        Response.Write("[");
    
        foreach(var item in Items)
        {
             Response.Write(JsonSerializer.Serialize(item));
    
            if ( /*not last*/)
            {
                Response.Write(",");
            }
        }
    
        Response.Write("]");   
    
        return new EmptyResult();
    }
