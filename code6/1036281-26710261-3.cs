    public class Presenter
    {
        private readonly IPresentationModel _model;
        public Presenter(IPresentationModel model)
        {
            _model = model;
            _model.SaveData += SaveData;
            _model.LoadData += LoadData;
        }
        private void LoadData(object sender, EventArgs e)
        {
            // TODO: Load model data to storage service
            // Loading mock data.
            _model.AProperty = "42";
        }
        private void SaveData(object sender, EventArgs e)
        {
            // TODO: Save model data to storage service
        }
    }
