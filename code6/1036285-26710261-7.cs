    public class Presenter
    {
        private readonly IPresentationModel _model;
        private static string _fakeService = "42";
        public Presenter(IPresentationModel model)
        {
            _model = model;
            _model.SaveData += SaveData;
            _model.LoadData += LoadData;
        }
        private void LoadData(object sender, EventArgs e)
        {
            _model.AProperty = _fakeService;
            _model.ATextbox = _fakeService;
        }
        private void SaveData(object sender, EventArgs e)
        {
            _fakeService = _model.ATextbox;
        }
    }
