     public List<dynamic> Select(string sql) {
            
            var list = new List<dynamic>();
 
            // ... your code to connect to database, execute sql as datareader ...
            // I recommend you Google the using statement, and use that to dispose
            // your connection and reader
            while (dataReader.Read())
            {
               var obj = new ExpandoObject();
               var d = obj as IDictionary<String, object>;
               for( int index = 0; index < reader.FieldCount; index ++ )
                  d[ reader.GetName( index ) ] = reader.GetString( index );
               list.Add(obj);
            }
            return list;
      }
