    public class StoryBoardBehaviour : DependencyObject
    {
        public static readonly DependencyProperty AttachCompletedHandlerProperty =
            DependencyProperty.Register("AttachCompletedHandler", typeof(bool), typeof(StoryBoardBehaviour), new PropertyMetadata(false, AttachCompletedHandlerChanged));
        public static void SetAttachCompletedHandler(DependencyObject obj, bool value)
        {
            obj.SetValue(AttachCompletedHandlerProperty, value);
        }
        public static bool GetAttachCompletedHandler(DependencyObject obj)
        {
            return (bool)obj.GetValue(AttachCompletedHandlerProperty);
        }
        private static void AttachCompletedHandlerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var storyboard = (Storyboard)d;
            var oldValue = (bool)e.OldValue;
            var newValue = (bool)e.NewValue;
            if (newValue && !oldValue)
            {
                storyboard.Completed += StoryboardOnCompleted;
            }
            if (!newValue && oldValue)
            {
                storyboard.Completed -= StoryboardOnCompleted;
            }
        }
        private static void StoryboardOnCompleted(object sender, object o)
        {
            // Completed handler logic
        }
    }
