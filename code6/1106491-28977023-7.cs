    [HttpPost]
    public JsonResult Create(int musicaID)
    {
      var userID = // you should know this on the server
      // call a service that saves the userID and musicaID to the database
      var usuariomusica = new UsuarioMusica()
      {
        UserId = userID,
        MusicId = musicaID
      };
      db.UsuarioMusicas.Add(usuariomusica);
      db.SaveChanges();
      return Json(true);
    }
