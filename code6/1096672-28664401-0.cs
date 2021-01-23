    namespace Test {
      public class WorkaroundForTheBugOfPopupBehavior : Behavior<FrameworkElement> {
        private static readonly FieldInfo _menuDropAlignmentField;
    
        static WorkaroundForTheBugOfContextMenuBehavior() {
          _menuDropAlignmentField = typeof(SystemParameters).GetField("_menuDropAlignment", BindingFlags.NonPublic | BindingFlags.Static);
          System.Diagnostics.Debug.Assert(_menuDropAlignmentField != null);
          EnsureStandardPopupAlignment();
          SystemParameters.StaticPropertyChanged += OnStaticPropertyChanged;
        }
    
        private static void EnsureStandardPopupAlignment() {
          if (SystemParameters.MenuDropAlignment && _menuDropAlignmentField != null) {
            _menuDropAlignmentField.SetValue(null, false);
          }
        }
    
        private static void OnStaticPropertyChanged(object sender, PropertyChangedEventArgs e) {
          EnsureStandardPopupAlignment();
        }
      }
    }
