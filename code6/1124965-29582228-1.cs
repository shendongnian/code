    catch (DbUpdateException e)
    {
        var ex = e.GetBaseException() as SqlException;
        
        if (ex != null && ex.Number == 2601)
        {
            ModelState.AddModelError("", "Unit number already exists");
        }
        else
        {
             //The exception was some other kind we weren't expecting
             //Let the exception bubble.
             throw;
        }
    }
