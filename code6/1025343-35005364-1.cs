     // Add some queries ie. ThreadedQuery.NamedQuery([Name], [SQL])
     var namedQueries= new ThreadedQuery.NamedQuery[]{ ... };
     System.Data.DataSet ds = ThreadedQuery.RunThreadedQuery(
     "Server=foo;Database=bar;Trusted_Connection=True;", 
     namedQueries).Result;
     string msg = string.Empty;
     foreach (System.Data.DataTable tt in ds.Tables)
     msg += string.Format("{0}: {1}\r\n", tt.TableName, tt.Rows.Count);
