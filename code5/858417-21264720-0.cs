    public class RuleGroup
    {
        public String Description { get; set; }
        public ObservableCollection<Rule> Rules { get; set; }
        public RuleGroup()
        {
            Rules = new ObservableCollection<Rule>();
        }
    }
