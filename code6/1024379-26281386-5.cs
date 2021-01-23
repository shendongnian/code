    using (var transaction = this.Context.Database.BeginTransaction())
    {
        try
        {
    
            if (quiz.PasswordRequiredToTakeQuiz())
            {
                // Attempt to use password
                UsePasswordResult result = this.Context.Database.SqlQuery<UsePasswordResult>("CALL UsePassword({0}, {1})", quiz.Id, model.QuizPassword).FirstOrDefault();
    
                // Check the result of the password use
                if (result.Success != 1)
                {
                    // Failed to use the password
                    ViewData.ModelState.AddModelError("QuizPassword", "Sorry the password you provided has expired or is not valid for this quiz");
                }
            }
    
            // Is model state still valid after password checks?
            if (ModelState.IsValid)
            {
                // Do stuff
            }
    
            transaction.Commit();
        }
        catch(Exception)
        {
            transaction.Rollback();
        }
        finally
        {
            transaction.Dispose();
        }
    }
