    public sealed class ProfileModel
    {
        public ProfileModel()
        {
            DataLayout = new DataLayoutOptionsModel();
        }
        public ProfileModel(DataLayoutOptionsModel dataLayout)
        {
            DataLayout = dataLayout;
        }
        public DataLayoutOptionsModel DataLayout { get; private set; }
    }
    public sealed class DataLayoutOptionsModel
    {
        public bool Vertical { get; set; }
    }
    public class ResultModel
    {
        public string Message { get; set; }
        public ProfileModel Result { get; set; }
    }
