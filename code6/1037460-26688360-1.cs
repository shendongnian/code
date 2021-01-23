    public class WpfControlFactory
    {
      public static IWpfControl CreateWpfControl(WpfControl control, string controlName)
      {
        IWpfControl wpfControl = default(IWpfControl);
        Type type = GetControl(control);
        if (type != null && type.IsAssignableFrom(typeof(IWpfControl)))
        {
            wpfControl = (IWpfControl)Activator.CreateInstance(type);
        }
        if (wpfControl != null)
        {
            wpfControl.Name = controlName ?? Consts.DefaultEaControlName;
        }
        return wpfControl;
      }
      private Type GetControl( WpfControl control )
      {
         switch ( control )
         {
            case WpfControl.Foo : return typeof( FooControlType );
            ...
         }
      }
    }
