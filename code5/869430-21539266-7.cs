    public static void EagerLoadEntityA( int aId )
    {
        using( var db = new TestEntities() )
        {
            // if using code first
            db.Database.Initialize( false );
            var cmd = db.Database.Connection.CreateCommand();
            cmd.CommandText = "dbo.Get_EntityA_by_Id";
            db.Database.Connection.Open();
            try
            {
                var reader = cmd.ExecuteReader();
                var objContext = ( ( IObjectContextAdapter )db ).ObjectContext;
                var aEntities = objContext
                    .Translate<EntityA>( reader, "EntityAs", MergeOption.AppendOnly );
                reader.NextResult();
                var bEntities = objContext
                    .Translate<EntityB>( reader, "EntityBs", MergeOption.AppendOnly );
            }
            finally
            {
                db.Database.Connection.Close();
            }
        }
    }
