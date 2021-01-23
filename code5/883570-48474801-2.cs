    public class ContentControlForegroundBindingBehavior : Behavior<Control>
    {
        public static DependencyProperty ParentProperty =
            DependencyProperty.Register("Parent", typeof(Control),
                typeof(ContentControlForegroundBindingBehavior), new PropertyMetadata(null));
    
        public Control Parent
        {
            get { return (Control)this.GetValue(ParentProperty); }
            set { this.SetValue(ParentProperty, value); }
        }
    
    
        protected override void OnAttached()
        {
            base.OnAttached();
    
            AssociatedObject.Loaded += (sender, e) =>
            {
                if (Parent == null) return;
    
                var control = AssociatedObject as Control;
                if (control == null) return;
    
    
                var contentControl = Parent.FindDescendantsOfType<ContentControl>().FirstOrDefault();
                if (contentControl == null) return;
    
                control.SetBinding(Control.ForegroundProperty, new Binding()
                {
                    NotifyOnSourceUpdated = true,
                    Mode = BindingMode.OneWay,
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                    BindsDirectlyToSource = true,
                    Path = new PropertyPath(Control.ForegroundProperty),
                    Source = contentControl
                });
            };
        }
    }
