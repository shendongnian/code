        [AcceptVerbs("Patch"), ResponseType(typeof(void))]
        public IHttpActionResult PatchUser(string id, Delta<Team> changes)
        {
            User userToUpdate = db.Users.Where(u => u.id == id).FirstOrDefault();
            if (userToUpdate == null) 
               return NotFound();
 
            changes.Patch(userToUpdate);
            try
            {                
                db.SaveChanges()
            }
            catch (DbUpdateException)
            {
               ...
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
