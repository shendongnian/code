    public class MyControl
    {
      public int Result { get; private set; }
      public string Text { get; private set; }
      public MyControl(int result, string text = "success")
      {
        Result = result;
        Text = text;
      }
    }
    
    public class MyClass
    {
      public void MyMethod()
      {
        //...
        var control = new MyControl(123);
        if (string.IsNullOrEmpty(error)) return;
        control.text = error;
        //...
      }
    }
