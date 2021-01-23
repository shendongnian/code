    [HttpPost, ActionName("UpdateTitle")]
    public IHttpActionResult UpdateTitle(PlaylistDto Dto)
    {
        using (ITransaction transaction = Session.BeginTransaction())
        {
            PlaylistManager.UpdateTitle(Dto.playlistId, Dto.title);
    
            transaction.Commit();
        }
    
        return Ok();
    }
