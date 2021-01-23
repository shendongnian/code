csharp
// using ReactiveUI.Fody
[Reactive]
public ReactiveCommand<TQuery, IEnumerable<TResult> SearchCommand { get; set; }
private CompositeDisposable Disposables { get; } = new CompositeDisposable();
### In the Constructor
// hook up the command
var searchCommand = ReactiveCommand.CreateFromTask<TQuery, IEnumerable<TResult>>((query, ct) => DoSearchAsync(query, ct)));
SearchCommand = searchCommand;
// don't forget to subscribe and dispose
Disposables.Add(searchCommand.Subscribe(result => Result = result));
