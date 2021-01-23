            try
            {
                var numInserted = DbUtils.IgnoreErrors(_db, () => DbUtils.InsertEntity(_db, someEntity), DbUtils.IsDuplicateInsertError).Item1;
                // no FK exception, but maybe unique index violation, safe
                // to keep going with transaction
            }
            catch (DbUpdateException e)
            {
                if (DbUtils.IsForeignKeyError(e))
                {
                  // you know what to do
                }
                throw; // rethrow other db errors
            }
