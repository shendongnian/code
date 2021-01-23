    class Program
    {
        static void Main( string[] args )
        {
            using( var db = new DBFirst.EFMREntities() )
            {
                db.Database.Initialize( force: false );
                try
                {
                    db.Database.Connection.Open();
                    var objContext = ( db as IObjectContextAdapter ).ObjectContext;
                    // mode 0 returns a result set
                    var reader = GetCmd( db, 0 ).ExecuteReader();
                    var entityResults = objContext
                        .Translate<DBFirst.Watch>( reader, 
                            // next two parms only if you want results in an entity set
                            "Watches", MergeOption.OverwriteChanges );
                    // mode 2 returns a scalar
                    var scalarResult = GetCmd( db, 2 ).ExecuteScalar();
                    // mode 1 does not return a result set
                    var cmd = GetCmd( db, 1 );
                    var nonQueryResult = cmd.ExecuteNonQuery();
                    var nonQueryReturnParm = cmd.Parameters[ "@RETURN_VALUE" ];
                    var nqrpValue = Convert.IsDBNull( nonQueryReturnParm.Value ) ? null : ( int? )nonQueryReturnParm.Value;
                    Console.WriteLine( "Entities returned: {0}", entityResults.Count() );
                    Console.WriteLine( "Scalar result: {0}", scalarResult );
                    Console.WriteLine( "Non-query results: {0} / {1}", nonQueryResult, nqrpValue );
                }
                finally
                {
                    db.Database.Connection.Close();
                }
            }
            
            Console.ReadLine();
        }
        private static DbCommand GetCmd( DbContext context, int value )
        {
            var cmd = context.Database.Connection.CreateCommand();
            
            var inParm = cmd.CreateParameter();
            inParm.ParameterName = "@mode";
            inParm.Value = value;
            var outParm = cmd.CreateParameter();
            outParm.ParameterName = "@RETURN_VALUE";
            outParm.Direction = ParameterDirection.ReturnValue;
            cmd.CommandText = "dbo.FuzzyResultSet";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange( new []{ inParm, outParm } );
            return cmd;
        }
    }
