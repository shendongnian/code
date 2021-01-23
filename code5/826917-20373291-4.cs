    public Task AddNewOperandAsync(Operand operand)
    {
        var tcs = new TaskCompletionSource<byte>();
        // Compose an event handler for the completion of this task
        NotifyCollectionChangedEventHandler onChanged = null;
        onChanged = (sender, e) =>
        {
            // Is this the event for the operand we have added?
            if (e.NewItems.Contains(operand))
            {
                // Complete the task.
                tcs.SetCompleted(0);
                // Remove the event-handler.
                _container.Operands.CollectionChanged -= onChanged;
            }
        }
        // Hook in the handler.
        _container.Operands.CollectionChanged += onChanged;
        
        // Perform the addition.
        _additions.Add(operand);
        // Return the task to be awaited.
        return tcs.Task;
    }
