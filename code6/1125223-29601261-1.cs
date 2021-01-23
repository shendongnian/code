    public Storyboard Storyboard
        {
            get { return (Storyboard)GetValue(StoryboardProperty); }
            set { SetValue(StoryboardProperty, value); }
        }
        public static readonly DependencyProperty StoryboardProperty =
            DependencyProperty.Register("Storyboard", typeof(Storyboard), typeof(StoryboardReactionBehavior), new PropertyMetadata(null, StoryboardChanged));
        private static void StoryboardChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = d as StoryboardReactionBehavior;
            if(behavior.Storyboard !=null)
            {
                behavior.Storyboard.Completed += (s, be) =>
                {
                    if (behavior.Command != null)
                    {
                        behavior.Command.Execute(null);
                    }
                };
            }
        }
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(StoryboardReactionBehavior), new PropertyMetadata(null));
