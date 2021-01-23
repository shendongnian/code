    public interface ISerializer<IList<BarcodeScannerModel>>
    {
        MemoryStream Serialize(IList<IList<BarcodeScannerModel>> list);
        MemoryStream Serialize(IList<BarcodeScannerModel> obj);
    }
