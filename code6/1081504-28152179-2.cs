    private List<ConditionalCommand> _ConditionList;
    
            public List<ConditionalCommand> ConditionList
            {
                get { return _ConditionList; }
                set
                {
                    if (_ConditionList != value)
                    {
                        _ConditionList = value;
                        OnPropertyChanged("ConditionList");
                    }
                }
            }
...
    class ConditionalCommand
    {
            public ICommand MyConditionalCommand { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return Name;
            }
    
    }
