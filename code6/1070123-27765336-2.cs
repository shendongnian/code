    public class MyCoolControl : Control
    {
      public Style LabeStyle
      {
        get { return (Style)GetValue(LabeStyleProperty); }
        set { SetValue(LabeStyleProperty, value); }
      }
      public static readonly DependencyProperty LabeStyleProperty =
        DependencyProperty.Register(
          "LabeStyle", typeof(Style), typeof(MyCoolControl));
      public Style DatePickerStyle
      {
        get { return (Style)GetValue(DatePickerStyleProperty); }
        set { SetValue(DatePickerStyleProperty, value); }
      }
      public static readonly DependencyProperty DatePickerStyleProperty =
        DependencyProperty.Register(
          "DatePickerStyle", typeof(Style), typeof(MyCoolControl));
      public object LabelContent
      {
        get { return (object)GetValue(LabelContentProperty); }
        set { SetValue(LabelContentProperty, value); }
      }
      public static readonly DependencyProperty LabelContentProperty =
        DependencyProperty.Register(
          "LabelContent", typeof(object), 
          typeof(MyCoolControl), new PropertyMetadata(null));
      static MyCoolControl()
      {
        DefaultStyleKeyProperty.OverrideMetadata(
          typeof(MyCoolControl), 
          new FrameworkPropertyMetadata(typeof(MyCoolControl)));
      }
    }
