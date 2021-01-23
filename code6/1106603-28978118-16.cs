    public HttpResponseMessage Put(int id,[FromBody]Search editFavorite)
    {
        if (_favRepo.EditFavorite(id, editFavorite))
        {
            _favRepo.Save()  
            return Request.CreateResponse(HttpStatusCode.Created, editFavorite);
        }
        return Request.CreateResponse(HttpStatusCode.BadRequest);
    }
