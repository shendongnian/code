    public delegate void ChangedEventHandler(object sender, EventArgs e);
    
    public class Test
    {
         public event ChangedEventHandler Changed;
    
         protected virtual void OnChanged(EventArgs e) 
          {
             if (Changed != null)
                Changed(this, e);
          }
    }
    
    public class UseEvent
    {
          public EventListener(Test test) 
          {
             test.Changed += new ChangedEventHandler(TestChanged);
          }
    
          private void TestChanged(object sender, EventArgs e) 
          {
             Console.WriteLine("Test Test");
          }
    }
