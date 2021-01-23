    public interface IPresentationModel
    {
        string AProperty { set; }
        string ATextbox { get; set; }
        event EventHandler SaveData;
        event EventHandler LoadData;
    }
