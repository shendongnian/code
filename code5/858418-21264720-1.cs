    public class Rule
    {
        public Rule()
        {
            Criteria = new ObservableCollection<Criteria>();
        }
        public String Description { get; set; }
        public ObservableCollection<Criteria> Criteria { get; set; }
        readonly ObservableCollection<RuleField> _Fields = new ObservableCollection<RuleField>();
        public IEnumerable<RuleField> Fields
        {
            get
            {
                return _Fields;
            }
        }
        public void AddField(string name, string header)
        {
            if (_Fields.FirstOrDefault(i => i.Name == name) == null)
            {
                RuleField field = new RuleField(_Fields.Count)
                {
                    Name = name,
                    Header = header
                };
                _Fields.Add(field);
                AddFieldToCriteria(field);
            }
        }
        void AddFieldToCriteria(RuleField field)
        {
            foreach (Criteria c in Criteria)
            {
                if (c.Values.FirstOrDefault(i => i.Field == field) == null)
                    c.Values.Add(new Criterion() { Field = field, Operation = 1 });
            }
        }
    }
