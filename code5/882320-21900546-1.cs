     public sealed class MYKeyboardDevice : KeyboardDevice
        {
            private sealed class MYPresentationSource : PresentationSource
            {
                Visual _rootVisual;
    
                protected override CompositionTarget GetCompositionTargetCore()
                {
                    throw new NotImplementedException();
                }
    
                public override bool IsDisposed
                {
                    get { return false; }
                }
    
                public override Visual RootVisual
                {
                    get { return _rootVisual; }
                    set { _rootVisual = value; }
                }
            }
    
            private static RoutedEvent s_testEvent = EventManager.RegisterRoutedEvent(
                    "Key Event",
                    RoutingStrategy.Bubble,
                    typeof(MYKeyboardDevice),
                    typeof(MYKeyboardDevice));
    
            public ModifierKeys ModifierKeysImpl;
    
            public MYKeyboardDevice()
                : this(InputManager.Current)
            {
    
            }
    
            public MYKeyboardDevice(InputManager manager)
                : base(manager)
            {
    
            }
    
            protected override KeyStates GetKeyStatesFromSystem(Key key)
            {
                var hasMod = false;
                switch (key)
                {
                    case Key.LeftAlt:
                    case Key.RightAlt:
                        hasMod = HasModifierKey(ModifierKeys.Alt);
                        break;
                    case Key.LeftCtrl:
                    case Key.RightCtrl:
                        hasMod = HasModifierKey(ModifierKeys.Control);
                        break;
                    case Key.LeftShift:
                    case Key.RightShift:
                        hasMod = HasModifierKey(ModifierKeys.Shift);
                        break;
                }
    
                return hasMod ? KeyStates.Down : KeyStates.None;
            }
    
            public KeyEventArgs CreateKeyEventArgs(
                Key key,
                ModifierKeys modKeys = ModifierKeys.None)
            {
                var arg = new KeyEventArgs(
                    this,
                    new MYPresentationSource(),
                    0,
                    key);
                ModifierKeysImpl = modKeys;
                arg.RoutedEvent = s_testEvent;
                return arg;
            }
    
            private bool RaiseEvents(UIElement target, RoutedEventArgs e, params RoutedEvent[] routedEventArray)
            {
                foreach (var routedEvent in routedEventArray)
                {
                    e.RoutedEvent = routedEvent;
                    target.RaiseEvent(e);
                    if (e.Handled)
                    {
                        return true;
                    }
                }
    
                return false;
            }
    
            private bool HasModifierKey(ModifierKeys modKey)
            {
                return 0 != (ModifierKeysImpl & modKey);
            }
        }
