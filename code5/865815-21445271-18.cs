    public interface IAddIn
    {
        bool OnLoad();
        string Version { get; set; }
        string Text { get; set; }
    }
