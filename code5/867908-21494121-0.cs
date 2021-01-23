    public class YourModel {
        public IList<Statistic> StudentStatistics { get; set; }
        public string GraphText {
            get {
                return StudentStatistics.Any() ? "" : "No statistics yet";
            }
        }
    }
