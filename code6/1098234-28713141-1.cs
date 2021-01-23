    public class Events {
      // Usually, you don't have to declare delegate:
      // there's a special class for it - EventHandler or EventHandler<T>
      public event EventHandler TestingEvt; // <- let's make it readable
    
      public void fireIt() {
        if (TestingEvt != null) {
          // Passing null is a bad practice, give EventArgs.Empty instead 
          TestingEvt(this, EventArgs.Empty);
        }
      }
      ...
    }
    
    ...
    private void tester(Object sender, EventArgs e) {
      // Events that fired the event - if you need it
      Events caller = sender as Events;
      ...
    }
    
    ...
    
    public void onLoad() {
      // Get the instance
      Events tempInstance = pf.getInstance("thisisaplugin", "Events") as Events;
      // Or just create an isntance
      // Events tempInstance = new tempInstance();
      ...
    
      // Assigning (adding) the event
      tempInstance.TestingEvt += tester; 
      ... 
    }
