    public ActionResult GetTRAsString(string appID)
    {
        // Populate revisions
        string html = "<ul>";
    
        foreach(RevesionInfo revInfo in revisions)
        {
            html += "<li>" + revInfo.RevDesc + "</li>";
        }
    
        html += "</ul>";
    
        return Content(html, "text/html");
    }
