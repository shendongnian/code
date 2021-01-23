        // GET: api/teams/5
        [ResponseType(typeof(teams))]
        public IHttpActionResult Getteams(long id)
        {
            teams teams = db.teams.Find(id);
            if (teams == null)
            {
                return NotFound();
            }
           return Ok(teams);
        }
