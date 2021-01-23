    public class Container
    {
        public object Object1 { get; set; }
        public object Object2 { get; set; }
    }
    var container = new Container { Object1 = obj, Object2 = obj2 };
    NavigationService.Navigate(new Uri("/Page.xaml?object1=" + container, UriKind.Relative));
