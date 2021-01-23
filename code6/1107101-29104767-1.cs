    var entityToWriteTo = ... // code that gets your entity
    var userRole = GetUserRole(entityToWriteTo);
    if (new[] {"Admin"}.Contains(userRole))
    {
        // write to admin-only entity properties
    }
    if (new[] {"Admin", "Leader"}.Contains(userRole))
    {
        // write to admin or leader entity properties
    }
    // Etc.
