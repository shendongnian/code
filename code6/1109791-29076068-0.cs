    // Somewhere to put the data:
    // for simplicity, I'll assume an instance field is fine; could
    // also be tracked via async-state object, if preferred
    private MemoryStream backlog = new MemoryStream();
    if (bytesRead > 0)
    {
        // we want to append, so move to the end
        backlog.Position = backlog.Length;
        // copy new data into the buffer
        backlog.Write(state.dataBuffer, 0, bytesRead);
        ...         
    } 
