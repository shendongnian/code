    public static class ActionExtensions
    {
        public static async void DelayFor(this Action act, TimeSpan delay)
        {
            await Task.Delay(delay);
            act();
        }
    }
    //usage
    Action toDo = () => doSomething(var1);
    toDo.DelayFor(TimeSpan.FromSeconds(3));
