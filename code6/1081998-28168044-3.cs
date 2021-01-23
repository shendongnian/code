    var ids = new DataTable()
    ids.Columns.Add("Id", typeof(int));
    foreach (var id in myList)
    {
        ids.Rows.Add(id);
    }
    var objList = myContext.SqlQuery<<entity>>(
        "[dbo].[Get<table>] @ids",
        new SqlParameter("@ids", SqDbType.Structured)
            { 
                Value = ids,
                TypeName = "[dbo].[IdSet]"
            }));
    
