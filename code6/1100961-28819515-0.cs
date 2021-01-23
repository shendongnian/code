    using System.Windows.Interactivity;
    class ClickBehavior : Behavior<Button>
    {
        // a dependency property for the command
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), 
                typeof(ClickBehavior), new PropertyMetadata(null));
        // a dependency property for the command's parameter        
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), 
                typeof(ClickBehavior), new PropertyMetadata(null));
        public ICommand Command
        {
            get { return (ICommand)this.GetValue(CommandProperty); }
            set { this.SetValue(CommandProperty, value); }
        }
        
        public object CommandParameter
        {
            get { return this.GetValue(CommandParameterProperty); }
            set { this.SetValue(CommandParameterProperty, value); }
        }
        // on attaching to a button, subscribe to its Click and MouseDoubleClick events
        protected override void OnAttached()
        {
            this.AssociatedObject.Click += this.AssociatedObject_Click;
            this.AssociatedObject.MouseDoubleClick += this.AssociatedObject_MouseDoubleClick;
        }
        // on detaching, unsubscribe to prevent memory leaks
        protected override void OnDetaching()
        {
            this.AssociatedObject.Click -= this.AssociatedObject_Click;
            this.AssociatedObject.MouseDoubleClick -= this.AssociatedObject_MouseDoubleClick;
        }        
        // move your event handlers here        
        private void AssociatedObject_Click(object sender, RoutedEventArgs e)
        { //... }        
        private void AssociatedObject_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        { //... }
        // call this method in your event handlers to execute the command
        private void ExecuteCommand()
        {
            if (this.Command != null && this.Command.CanExecute(this.CommandParameter))
            {
                this.Command.Execute(this.CommandParameter);
            }
        }
