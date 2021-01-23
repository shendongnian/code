        private static object InvokePrivateMethod(Type type, object obj, string methodName, params object[] arguments)
        {
            MethodInfo dynMethod = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
            return dynMethod.Invoke(obj, arguments);
        }
        private static async Task CSOM15ExecuteAsync(ClientRuntimeContext clientContext)
        {
            ClientRequest req = InvokePrivateMethod(typeof(ClientRuntimeContext), clientContext, "InitializeRequest") as ClientRequest;
            //ChunkStringBuilder sb = req.SetupQuery();
            var sb = InvokePrivateMethod(typeof(ClientRequest), req, "SetupQuery");
            
            //req.SetupServerQuery(sb);
            InvokePrivateMethod(typeof(ClientRequest), req, "SetupServerQuery", sb);
            await req.RequestExecutor.ExecuteAsync();
            
            //req.ProcessResponse();
            InvokePrivateMethod(typeof(ClientRequest), req, "ProcessResponse");
        }
