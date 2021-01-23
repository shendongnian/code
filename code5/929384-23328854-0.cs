    var areAllAvailable = new BehaviorSubject<bool>(true);
    PauseCommand = new ReactiveCommand(areAllAvailable);
    PlayCommand = new ReactiveCommand(areAllAvailable);
    Observable.CombineLatest(PauseCommand.IsExecuting, PlayCommand.IsExecuting, 
        (pa,pl) => !(pa || pl));
