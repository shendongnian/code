        // GET tables/User
        public IQueryable<User> GetAllUsers()
        {
            return Query().HideSensitiveProperties();
        }
        // GET tables/User/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<User> GetUser(string id)
        {
            return Lookup(id).HideSensitiveProperties();
        }
        // PATCH tables/User/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<User> PatchUser(string id, Delta<User> patch)
        {
            return UpdateAsync(id, patch).HideSensitivePropertiesForItem();
        }
        // POST tables/User
        public async Task<IHttpActionResult> PostUser(User item)
        {
            User current = await InsertAsync(item);
            current.HideSensitivePropertiesForItem();
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }
        // DELETE tables/User/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUser(string id)
        {
            return DeleteAsync(id);
        }
