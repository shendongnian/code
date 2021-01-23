    public interface IServiceWorker
    {
        void DoThisOneWay(string foo);
        void DoThisDifferently(string foo);
    }
    public void DoSomethingImportant(string foo)
    {
        if (someCondition)
        {
            _worker.DoThisOneWay(foo);
        }
        else
        {
            _worker.DoThisDifferently(foo);
        }
    }
