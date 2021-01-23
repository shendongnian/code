    public interface IPresentationModel
    {
        string AProperty { get; set; }
        event EventHandler SaveData;
        event EventHandler LoadData;
    }
