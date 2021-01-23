    internal interface IMyEntityStatusChange
    {
        DbContext Context { get; set; }
        void ChangeStatus(MyEntityStatusCode code);
    }
