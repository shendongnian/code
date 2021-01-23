    public delegate void UpdateColumnsEventHandler(object sender, UpdateColumnsEventArgs e);
    public class UpdateColumnsEventArgs
    {
        public IEnumerable<RuleField> Columns { get; set; }
        public UpdateColumnsEventArgs()
        {
            Columns = new List<RuleField>();
        }
        public UpdateColumnsEventArgs(IEnumerable<RuleField> columns)
        {
            Columns = columns;
        }
    }
    public class MainWindowViewModel
    {
        public event UpdateColumnsEventHandler UpdateColumns;
        public ObservableCollection<RuleGroup> RuleGroups { get; set; }
        RuleGroup _SelectedRuleGroup = null;
        public RuleGroup SelectedRuleGroup
        {
            get
            {
                return _SelectedRuleGroup;
            }
            set
            {
                if (_SelectedRuleGroup == value)
                    return;
                _SelectedRuleGroup = value;
            }
        }
        public Rule _SelectedRule = null;
        public Rule SelectedRule
        {
            get
            {
                return _SelectedRule;
            }
            set
            {
                if (_SelectedRule == value)
                    return;
                _SelectedRule = value;
                if (UpdateColumns != null)
                    UpdateColumns(this, new UpdateColumnsEventArgs(_SelectedRule.Fields));
            }
        }
        public MainWindowViewModel()
        {
            RuleGroups = new ObservableCollection<RuleGroup>();
            RuleGroup rg = new RuleGroup();
            rg.Description = "Rule Group A";
            Rule r = new Rule();
            r.Description = "Rule 1";
            Random random = new Random();
            int range = 10000;
            for (int x = 0; x < 2000; x++)
            {
                Criteria c = new Criteria();
                c.Values.Add(new Criterion()
                {
                    Field = new RuleField(0)
                    {
                        Name = "A",
                        Header = "A Column"
                    },
                    Operation = 1,
                    Value = "X"
                });
                c.Values.Add(new Criterion()
                {
                    Field = new RuleField(0)
                    {
                        Name = "B",
                        Header = "B Column"
                    },
                    Operation = 1,
                    Value = x % 10
                });
                r.Criteria.Add(c);
            }
            #region Fields
            r.AddField("A", "A Column");
            r.AddField("B", "B Column");
            r.AddField("C", "C Column");
            #endregion
            rg.Rules.Add(r);
            r = new Rule();
            r.Description = "Rule 2";
            for (int x = 0; x < 1750; x++)
            {
                r.Criteria.Add(new Criteria());
            }
            #region Fields
            r.AddField("A", "A Column");
            r.AddField("B", "B Column");
            #endregion
            rg.Rules.Add(r);
            RuleGroups.Add(rg);
        }
    }
