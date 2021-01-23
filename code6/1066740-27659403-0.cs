    interface ITimerAction
    {
        int Seconds { get; set; }
        bool Started { get; }
        bool Completed { get; }
        void OnStart();
        void OnComplete();
    }
    interface ITimerActionList
    {
        void Add(ITimerAction action);
        void Work();
        event EventHandler OnCompletedEvent;
    }
