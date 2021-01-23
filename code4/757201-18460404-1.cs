    var query2 = GraphClient
        .Cypher
        .Start(new { server = new NodeReference(1) })
        .Match("server-[:IS_SERVER_TYPE]->type", "appEnv-[:HAS_SERVER]->server", "app-[:HAS_ENV]->appEnv")
        .Return((server, appEnv, app) =>
            new
            {
                ServerId = Return.As<string>("server.ServerId"),
                EnvironmentTypeId = Return.As<string>("appEnv.EnvironmentTypeId"),
                AppEnvId = Return.As<string>("appEnv.AppEnvId"),
                AppId = Return.As<string>("app.AppId"),
                AppName = Return.As<string>("app.AppName"),
            });
    var results2 = query2.Results.GroupBy(g => g.ServerId).ToList();
