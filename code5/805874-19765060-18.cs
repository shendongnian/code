    public class PreviewKeyUpBehavior : Behavior<UIElement>
    {
        #region Properties
        
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(PeviewKeyUpBehavior));
        #endregion
        #region Methods
        protected override void OnAttached()
        {
            AssociatedObject.PreviewKeyUp += OnPreviewKeyUp;
            base.OnAttached();
        }
        private void OnPreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (Command == null) return;
            
            // Execute command and send the key as the command parameter
            Command.Execute(e.Key == Key.System ? e.SystemKey : e.Key);
        } 
        #endregion
    }
