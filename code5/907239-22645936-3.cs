    public class MyWindow : Window
    {
        ...
        public MyWindow()
        {
            // Attach event handler
            this.DataContextChanged += HandleDataContextChanged;
            // You may have to directly call the Handler as sometimes
            // DataContextChanged isn't raised on new windows, but only
            // when the DataContext actually changes.
        }
        void HandleDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var dc = DataContext as MarginDataContext;
            if (dc != null)
            {
                // Assuming there is a 'MyWindow' property on MarginDataContext
                dc.MyWindow = this;
            }
        }
    }
