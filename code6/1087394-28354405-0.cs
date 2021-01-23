    public class YourViewModel {
    public YourViewModel(Action<Action> beginInvoke)
    {
        this.BeginInvoke = beginInvoke;
    }
    protected Action<Action> BeginInvoke { get; private set; }
    private void SomeMethod()
    {
        this.BeginInvoke(() => DoSomething());
    } }
