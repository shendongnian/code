        public class PopoutTabItem : TabItem
    {
        public PopoutTabItem()
        {
            InputBindings.Add(new MouseBinding
                {
                    Gesture = new MouseGesture{Modifiers = ModifierKeys.Control | ModifierKeys.Shift, MouseAction = MouseAction.LeftClick},
                    Command = PopoutManager.ShowPopupCommand,
                    CommandParameter = this
                });
        }
    }
