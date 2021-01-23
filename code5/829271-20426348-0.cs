    public class doSomething
    {
        public void SomeMethod()
        {
            ...
            // delegate event handler
            ListView.SelectionChanged += delegateEventHandler;
            // or Lambda Expression
            ListView.SelectionChanged += (sender, args) => 
                                          {
                                              // Apply Logic
                                          };
        
            ...
        }
        
        public void delegateEventHandler(object sender, EventArgs eventArgs)
        {
            // apply logic...
        }
    }
