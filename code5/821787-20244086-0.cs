    public TabItemViewModel(IEventAggregator eventAggregator, ..){
        ...
        GiveFocusEvent setFocusEvent = eventAggregator.Get<GiveFocusEvent>();
        setFocusEvent.Subscribe(SetFocusEventHandler, ThreadOption.UIThread);
    }
    public void SetFocusEventHandler(){
         // change IsSelected property value..
    }
