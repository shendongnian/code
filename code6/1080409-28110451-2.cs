    public IHttpActionResult GetFavorites()
    {
      string userName = this.User.Identity.Name;
      if (!this.userService.IsAuthorized(userName))
      {
        return this.Unauthorized();
      }
      var favs = this.userService.GetFavorites(userName);
      return Ok(favs);
    }
