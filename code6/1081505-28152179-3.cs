     this.ConditionList = new List<ConditionalCommand>();
      this.ConditionList.Add(new ConditionalCommand{ MyConditionalCommand = DeleteCondition , Name="Delete"});
      this.ConditionList.Add(new ConditionalCommand{ MyConditionalCommand = DeleteSpecial, Name="Delete special" });
....
 
    private void DoDeleteCondition(object parameter)
        {
          //  if (parameter != null)
          //      ...
        }
    
        public ICommand DeleteCondition
        {
            get
            {
                if (_DeleteCondition == null) 
                    _DeleteCondition = new RelayCommand(o => DoDeleteCondition(o));
                return _DeleteCondition;
            }
        }
    // DeleteSpecial implemented in similar manner...
