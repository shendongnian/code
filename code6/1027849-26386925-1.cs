    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
            var mp = new MyPoint();
            var mv = new MyType<string>("Now is the time");
            mp.MyType = mv;
            MyPoint = mp;
        }
        public static readonly DependencyProperty PointDependencyProperty =
            DependencyProperty.Register(
              "MyPoint",
              typeof(MyPoint),  // This is the problem!
              typeof(MyUserControl));
        public MyPoint MyPoint
        {
            get { return (MyPoint)GetValue(PointDependencyProperty); }
            set { SetValue(PointDependencyProperty, value); }
        }
    }
    public class MyPoint
    {
        public dynamic MyType { get; set; }
    }
    public class MyType<T>
    {
        public dynamic Myvalue { get; set; }
        public Point MyPoint { get; set; }
        public MyType(T value)
        {
            Myvalue = value;
        }
    }
