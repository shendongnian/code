    bool shouldThrow = true;
    
    var reactiveCommandA = ReactiveCommand.CreateAsyncTask(_ => CanPossiblyThrowAsync());
    reactiveCommandA.ThrownExceptions
                    .Where(_ => shouldThrow)
                    .Subscribe(ex => UserError.Throw("Oh no A", ex));
    
    var reactiveCommandB = ReactiveCommand.CreateAsyncTask(_ => CanAlsoPossiblyThrowAsync());
    reactiveCommandB.ThrownExceptions
                    .Where(_ => shouldThrow)
                    .Subscribe(ex => UserError.Throw("Oh no B", ex));
    
    var reactiveCommandC = ReactiveCommand.CreateAsyncTask
       (
         async _ =>
                   {
                     shouldThrow = false;
                     
                     try
                     {
                         await reactiveCommandA.ExecuteAsync(); // <= Could throw here
                         await reactiveCommandB.ExecuteAsync();
                     }
    
                     finally
                     {
                         shouldThrow = true;
                     }
                     DoSomethingElse();
                   }
        );
    
    reactiveCommandC.ThrownExceptions
                    .Subscribe(ex => UserError.Throw("Oh no C", ex));
