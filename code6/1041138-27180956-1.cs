    static System.Threading.Tasks.Task ExecuteAsync(List<System.Threading.Tasks.Task<KeyValuePair<HttpStatusCode, WorkflowResponse>>> tasks)
        {
            return System.Threading.Tasks.Task.Run(async () =>
            {
                await System.Threading.Tasks.Task.WhenAll(tasks);
            });
        }
