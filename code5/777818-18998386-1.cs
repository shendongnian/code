    public class MyTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SimpleTemplate { get; set; }
        public DataTemplate ComplexTemplate { get; set; }
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            // Logic to decide with template to return goes here
            return // Either SimpleTemplate or ComplexTemplate
        }
    }
