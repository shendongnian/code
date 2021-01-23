    public class MyClass : Border
    {
        public Building MyBuilding
        {
            get { return (Building)GetValue(MyBuildingProperty); }
            set { SetValue(MyBuildingProperty, value); }
        }
        public static readonly DependencyProperty MyBuildingProperty =
            DependencyProperty.Register("MyBuilding", typeof(Building),
                                         typeof(MyClass));
        
    }
