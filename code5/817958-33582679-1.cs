    public class Issue {
        public Issue() {
            WorkItems = new List<WorkItem>();
        }
        public String Id {
            get; set;
        }
        public List<WorkItem> WorkItems { get; private set; }
    }
