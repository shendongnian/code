    public class MyWindow
    {
       private static readonly RoutedCommand DummyEmptyCommand = new RoutedCommand("DummyEmptyCommand", typeof(MyWindow), new InputGestureCollection() { new KeyGesture(Key.F4) });
       
       public MyWindow()
       {
          MyComboBox.CommandBindings.Add(new CommandBinding(DummyEmptyCommand, (o, e) => 
          { 
             // Do your work here or simply leave it blank to disable F4 common behavior;
          }));
       }
    }
