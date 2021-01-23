    public class KeyTriggerThatWorks : TriggerBase<FrameworkElement>
    {
        private FrameworkElement _target;
            
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Loaded += (sender, args) =>
            {
                _target = AssociatedObject;
                _target.KeyDown += new KeyEventHandler(Visual_KeyDown);
            };  
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            _target.KeyDown -= new KeyEventHandler(Visual_KeyDown);   
        }
        public Key Key { get; set; }
        void Visual_KeyDown(object sender, KeyEventArgs args)
        {
            if (Key == args.Key)
                InvokeActions(Key);
        }  
    }
