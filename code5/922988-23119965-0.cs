    var engine = new ScriptEngine();
    var session = engine.CreateSession();
    // implement your expression here
    session.Execute(@"Function ExecuteExpression As Boolean
        Return True
    End Function");
    //var result = session.Execute<bool>("ExecuteExpression"); // error
    var result = (bool)session.Execute("ExecuteExpression");
