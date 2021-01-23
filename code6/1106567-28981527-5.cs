    interface IWorkSpaceViewControl
    {
        void GetSelectedEntry();
        void Refresh();
        bool CanSave { get; }
        void Save();
    }
