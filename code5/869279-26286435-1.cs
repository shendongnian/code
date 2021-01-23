        public static void HandleCompletion(
            this IDataflowBlock source, params IDataflowBlock[] targets)
        {
            source.Completion.ContinueWith(
                task =>
                {
                    foreach (var target in targets)
                    {
                        if (task.IsFaulted)
                            target.Fault(task.Exception);
                        else
                            target.Complete();
                    }
                });
        }
