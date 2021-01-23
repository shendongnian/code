    public class UniqueNameBehavior : Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            //assign unique name to the associated element, for example:
            AssociatedObject.Name = Guid.NewGuid().ToString().Replace("-", null);
        }
    }
