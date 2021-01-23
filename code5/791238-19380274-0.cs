    public class MyStyleSelector : StyleSelector
    {
        public Style RegularStyle { get; set; }
        
        public Style ErrorStyle { get; set; }
        public override Style SelectStyle(object item, System.Windows.DependencyObject container)
        {
            var model = item as YourModel;
            // Here you determine which style to use based on the property in your model
            if (model.Error)
            {
                return ErrorStyle;
            }
            return RegularStyle;
        }
    }
