    public async Task<IHttpActionResult> PutTodo(Todo todo)
    {
        if (!ModelState.IsValid || todo == null)
        {
            return BadRequest(ModelState);
        }
        var original = await _db.Todos.AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == todo.Id);
        if (original == null) return NotFound();
        if (original.CreatorId != _currentUser.Id || original.CreatorId != todo.CreatorId)
        {
            return StatusCode(HttpStatusCode.Forbidden);
        }
        _db.Entry(todo).State = EntityState.Modified; // Exception thrown here
        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TodoExists(todo.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return StatusCode(HttpStatusCode.NoContent);
    }
