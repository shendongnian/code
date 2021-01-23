    public class BackgroundChanger : DependencyObject
    {
        // make property Brush Background
        // type "propdp", press "tab" and complete filling
        private static void OnStatusChange(DependencyObject obj,  DependencyPropertyChangedEventArgs e) 
        {
            var element = obj as Control;
            if (element != null)
            {
                if ((bool)e.NewValue)
                    element.Background = GetBrush(obj); // getting another attached property value
                else
                    element.Background = default(Brush);
            }
        }
    }
