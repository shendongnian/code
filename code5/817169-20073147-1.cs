    using(var conn = new SqlConnection(ConnectionString))
    {
        var rows = conn.Query(@"
    select ID, Step, StateID, SenderNo
    from (
        select *, row_number() over(partition by ID order by Step desc) as [_row]
        from Process) x where x.[_row]=1").ToList();
        foreach(var row in rows)
        {
            Console.WriteLine(row.ID); // dynamic member resolution
            Console.WriteLine(row.Step);
            //...             
        }
    }
