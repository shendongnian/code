    public class VM
    {
        public A A { get; set; }
        public B B { get; set; }
        public C C { get; set; }
    }
    public class A { }
    public class B { }
    public class C { }
    public class MySelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null)
            {
                return (DataTemplate)((FrameworkElement)container).FindResource("dtpl" + item.GetType().Name);
            }
            else
            {
                return base.SelectTemplate(item, container);
            }
        }
    }
