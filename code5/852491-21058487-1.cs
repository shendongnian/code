    var tag = db.Tags.SingleOrDefault(t => t.id == id);
    
    if (tag == null) 
    {
        return Request.CreateResponse(HttpStatusCode.NotFound);
    }
    if (tag.Pages.Any()) 
    {
        return Request.CreateResponse(
            HttpStatusCode.BadRequest, 
            "A tag must not be assigned to any page before you delete it"
        );
    }
    db.Tags.Remove(tag);
    db.SaveChanges();
    return Request.CreateResponse(HttpStatusCode.OK, tag);
