    public class CustomControl : UserControlBase
    {
           public String MyString { get; set; }
           public String AString { get; set; }
           [Description("Some description"), Category("Data")]
           public MyClass MyClass { get; set; }
          
    }
