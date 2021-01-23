    public static class DbUtils
    {
        /// <summary>
        ///     Takes a code block that updates database, runs it and catches db exceptions. If the caught
        ///     exception is one of those that are ok to ignore (okToIgnoreChecks) then no
        ///     exception is raised and result is returned. Otherwise an exception is rethrown.
        /// 
        ///     This function is intended to be run within an explicit transaction, i.e.:
        ///     using (var transaction = db.Database.BeginTransaction()), which should be committed/rolledback afterwards.
        ///     Otherwise, if you don't use a transaction discard the db context or in other words make this operation
        ///     the only one that you run within implicit transaction.
        /// 
        ///     This function can wrap a single DB statement, but it's more efficient to wrap multiple statements
        ///     so that locks are held for shorter period of time.
        ///     If an exception occurs within a transaction and is caught by this function, all other changes
        ///     will be still saved to DB on commit if transaction is used.
        /// </summary>
        /// <typeparam name="T">Any result returned by the code block</typeparam>
        /// <param name="context">Database connection</param>
        /// <param name="dbCodeBlock">
        ///     Code block to execute that updates DB. It's expected, but not critical that
        ///     this code does not throw any other exceptions. Do not call SaveChanges() from the code block itself. Let this
        ///     function do it for you.
        /// </param>
        /// <param name="okToIgnoreChecks">
        ///     List of functions that will check if an exception can be ignored.
        /// </param>
        /// <returns>Returns number of rows affected in DB and result produced by the code block</returns>
        public static Tuple<int, T> IgnoreErrors<T>(DbContext context,
            Func<T> dbCodeBlock, params Func<DbUpdateException, bool>[] okToIgnoreChecks)
        {
            var result = dbCodeBlock();
            try
            {
                var rowsAffected = context.SaveChanges();
                return Tuple.Create(rowsAffected, result);
            }
            catch (DbUpdateException e)
            {
                if (okToIgnoreChecks.Any(check => check(e)))
                    return Tuple.Create(0, result);
                throw;
            }
        }
        public static bool IsDuplicateInsertError(DbUpdateException e)
        {
            return GetErrorCode(e) == 2601;
        }
        public static bool IsForeignKeyError(DbUpdateException e)
        {
            return GetErrorCode(e) == 547;
        }
        public static T UpdateEntity<T>(DbContext context, T entity, Action<T> entityModifications)
            where T : class
        {
            return EntityCrud(context, entity, (db, e) =>
            {
                db.Attach(e);
                entityModifications(e);
                return e;
            });
        }
        public static T DeleteEntity<T>(DbContext context, T entity)
            where T : class
        {
            return EntityCrud(context, entity, (db, e) => db.Remove(e));
        }
        public static T InsertEntity<T>(DbContext context, T entity)
            where T : class
        {
            return EntityCrud(context, entity, (db, e) => db.Add(e));
        }
        public static T EntityCrud<T>(DbContext context, T entity, Func<DbSet<T>, T, T> crudAction)
            where T : class
        {
            return crudAction(context.Set<T>(), entity);
        }
    }
