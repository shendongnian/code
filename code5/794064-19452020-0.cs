    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Interactivity;
    public class ScrollToFirstInvalidElementBehavior : Behavior<ScrollViewer>
    {
        protected override void OnAttached()
        {
            ResetEventHandlers(null, AssociatedObject.DataContext);
            AssociatedObject.DataContextChanged += OnDataContextChanged;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.DataContextChanged -= OnDataContextChanged;
        }
        private void OnDataContextChanged(object sender, 
              DependencyPropertyChangedEventArgs e)
        {
            ResetEventHandlers(e.OldValue, e.NewValue);
        }
        private void ResetEventHandlers(object oldValue, object newValue)
        {
            var oldContext = oldValue as INotifyPropertyChanged;
            if (oldContext != null)
            {
                oldContext.PropertyChanged -= OnDataContextPropertyChanged;
            }
            var newContext = newValue as INotifyPropertyChanged;
            if (newContext is IDataErrorInfo)
            {
                newContext.PropertyChanged += OnDataContextPropertyChanged;
            }
        }
        private void OnDataContextPropertyChanged(object sender, 
             PropertyChangedEventArgs e)
        {
            var dataError = (IDataErrorInfo) sender;
            if (!string.IsNullOrEmpty(dataError.Error))
            {
                var controlInError = GetFirstChildControlWithError(AssociatedObject);
                if (controlInError != null)
                {
                    controlInError.BringIntoView();
                }
            }
        }
        private Control GetFirstChildControlWithError(ScrollViewer AssociatedObject)
        {
            //...
        }
    }
