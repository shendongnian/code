    using System.Threading.Tasks;
    Task.Factory.StartNew(()=> 
    {
        // Do some unit of Work
        // .......
        
        // now check if the task has been cancelled.
        token.ThrowIfCancellationRequested();
        // Do some more work
        // .......
        // now check if the task has been cancelled.
        token.ThrowIfCancellationRequested();
    }, token);
