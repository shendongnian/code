    [HttpPatch]
    public void UpdatePartially(int id, JsonPatchOperation[] patchOperations)
    {
        if (id > 0)
        {
            // DatabaseAccessor is just a wrapper around my DataContext object
            using (DatabaseAccessor db = new DatabaseAccessor())
            {
                SetDataLoadOptions(db); // optional of course
                var item = db.context.Items.Single(i => i.id == id);
                foreach (JsonPatchOperation patchOperation in patchOperations)
                {
                    // when you want to set a foreign key identifier, LINQ-to-SQL throw a ForeignKeyReferenceAlreadyHasValueException
                    // the patchOperation will then use GetForeignKeyObject to fetch the object that it requires to set the foreign key object instead
                    patchOperation.GetForeignKeyObject = (PropertyInfo property, object identifier) =>
                    {
                        // this is just example code, make sure to correct this for the possible properties of your object...
                        if (property == typeof(Item).GetProperty("JobStatus", typeof(JobStatus)))
                        {
                            return db.context.JobStatus.Single(js => js.StatusId == (int)identifier);
                        }
                        else if (property == typeof(Item).GetProperty("User", typeof(User)))
                        {
                            return db.context.Users.Single(u => u.UserId == (Guid)identifier);
                        }
                        throw new ArgumentOutOfRangeException("property", String.Format("Missing getter for property '{0}'.", property.Name));
                    };
                    patchOperation.ApplyTo(item);
                }
                db.context.SubmitChanges();
            }
        }
    }
