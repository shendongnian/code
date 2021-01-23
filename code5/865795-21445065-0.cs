    // server1
    var query1 = ExecuteQueryTapAsync(clientctx);
    // ...
    
    // server2
    var query2 = ExecuteQueryTapAsync(clientctx);
    // ...
    
    await Task.WhenAll(query1, query2);
