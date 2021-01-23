    catch (DbUpdateException e)
    {
        bool handled = false;
        if (e.InnerException != null && e.InnerException is UpdateException)
        {
            var ex = e.InnerException.InnerException as SqlException;
            if (ex != null && ex.Number == 2601)
            {
                ModelState.AddModelError("", "Unit number already exists");
                handled = true;
            }
         }
         
         //The exception was some other kind we weren't expecting
         //Let the exception bubble.
         if(!handled)
             throw;
    }
