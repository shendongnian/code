    //Some authorization logic:
    //  Only let a request enter this action if the author of
    //  the request has been verified
    [Authorize]
    [HttpDelete]
    [Route("resource/{id}")]
    public IHttpActionResult Delete(Guid id)
    {
        var resourceOwner = GetResourceOwner(id);
        //Some permissions logic:
        //  Only allow deletion of the resource if the
        //  user is both an admin and the owner.
        if (!User.IsInRole("admin") || User.Identity.Name != resourceOwner)
        {
            return StatusCode(HttpStatusCode.Forbidden);
        }
        DeleteResource(id);
        return StatusCode(HttpStatusCode.NoContent);
    }
