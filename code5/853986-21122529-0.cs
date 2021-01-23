    class MyEventListner 
    {
        Dictionary<string, string> fields = new Dictionary<string, string>();
        public MyObject Data {get;private set;}
    
        void HandleEvent1(EventData eventData) { fields["Field1"] = eventData.Field;}
        void HandleEvent2(EventData2 eventData) { fields["Field2"] = eventData.FieldFoo;}
        void HandleEvent3(EventData eventData) { 
           Data  = new MyObject { 
              Field1 = fields["Field1"],
              Field2 = fields["Field2"],
              Filed3 = eventData.Field
        }
    }
    
    MyEventListner listener = new MyEventListner ();
    WhateverEventManager eventManager = new eventManager();
    
    void Subscribe()
    {
        eventManager.OneEvent += d => listener.HandleEvent1(d);
        eventManager.OtherEvent += d => listener.HandleEvent2(d);
        eventManager.LastEvent += d => listener.HandleEvent3(d);
    }
