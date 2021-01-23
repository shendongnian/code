    public partial class TextBinder:UserControl
    {
    
      public static readonly DependencyProperty textproperty = 
      DependencyProperty.Register("Text", typeof(string), typeof(TextBinder));
   
      public string Text
      {
        get
        {
            return this.GetValue(textproperty) as string;
        }
        set
        {
            this.SetValue(textproperty,value);
        }
      }
    }
