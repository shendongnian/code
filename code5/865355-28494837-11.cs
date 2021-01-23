    namespace System.Web.Helpers
    {
        public class Chart
        {
            public Chart(int width, int height, string template = null, string templatePath = null);
            public string FileName { get; }
            public int Height { get; }
            public int Width { get; }
            public Chart AddLegend(string title = null, string name = null);
            public Chart AddSeries(string name = null, string chartType = "Column", string chartArea = null, string axisLabel = null, string legend = null, int markerStep = 1, IEnumerable xValue = null, string xField = null, IEnumerable yValues = null, string yFields = null);
            public Chart AddTitle(string text = null, string name = null);
            public Chart DataBindCrossTable(IEnumerable dataSource, string groupByField, string xField, string yFields, string otherFields = null, string pointSortOrder = "Ascending");
            public Chart DataBindTable(IEnumerable dataSource, string xField = null);
            public byte[] GetBytes(string format = "jpeg");
            public static Chart GetFromCache(string key);
            public Chart Save(string path, string format = "jpeg");
            public string SaveToCache(string key = null, int minutesToCache = 20, bool slidingExpiration = true);
            public Chart SaveXml(string path);
            public Chart SetXAxis(string title = "", double min = 0, double max = 0.0 / 0.0);
            public Chart SetYAxis(string title = "", double min = 0, double max = 0.0 / 0.0);
            public WebImage ToWebImage(string format = "jpeg");
            public Chart Write(string format = "jpeg");
            public static Chart WriteFromCache(string key, string format = "jpeg");
        }
    }
