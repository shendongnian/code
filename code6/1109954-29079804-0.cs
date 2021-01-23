    public class Example<TPlotModel> where TPlotModel : IPlotModel, new()
    {
        public TPlotModel PlotModel { get; private set; }
        public Example()
        {
            this.PlotModel = new TPlotModel();
        }
    }
