    public class RaiseEventBehavior : Behavior<UIElement>
    {
        protected override void OnAttached()
        {
            AssociatedObject.KeyUp += (sender, e) => 
            {
                TreeView topic = sender as TreeView;
                string keyValue = e.Key.ToString();
                if (keyValue == "Return")
                {
                 //do something here
                }
            };
        }
    }
