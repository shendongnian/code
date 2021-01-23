    private sealed class WhenAllPromise : Task<VoidTaskResult>, ITaskCompletionAction
    {
        public void Invoke(Task completedTask)
        {
            ...
            // Decrement the count, and only continue to complete the promise if we're the last one.
            if (Interlocked.Decrement(ref m_count) == 0)
            {
                ...
                for (int i = 0; i < m_tasks.Length; i++)
                {
                    ...
                    // Regardless of completion state, if the task has its debug bit set, transfer it to the
                    // WhenAll task.  We must do this before we complete the task.
                    if (task.IsWaitNotificationEnabled) this.SetNotificationForWaitCompletion(enabled: true);
                    else m_tasks[i] = null; // avoid holding onto tasks unnecessarily
                }
            }
        }
    }
