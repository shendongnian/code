            private static Task AddContinueWithToTask(Task task, object userContext, Action<System.Exception> onExceptionCallback = null, Action<Task> onCompletedCallback = null)
            {
                return task
                    .ContinueWith(t => {
                        if (t.IsFaulted)
                            ManageException(t, userContext, onExceptionCallback);
                    })
                    .ContinueWith(t2 => 
                    {
                        if (onCompletedCallback != null) onCompletedCallback(t2); 
                    })
                    .ContinueWith(t => {
                        if (t.IsFaulted)
                            ManageException(t, userContext, onExceptionCallback);
                    })
                    ;
            }
