    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public Base Base
        {
            get { return new Child(); }
        }
        public List<Base> BaseCollection
        {
            get { return new List<Base> { new Child(), new Child(), new Child2(), new Child2() }; }
        }
    }
    public abstract class Base
    {
        public virtual string Name
        {
            get { return "I'm a Base class"; }         
        }        
    }
    public class Child : Base
    {
        public override string Name
        {
            get { return "I'm A child"; }
        }
    }
    public class Child2 : Base
    {
    }
