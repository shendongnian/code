    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            ListBox properties = new ListBox();
            ObservableCollection<Object> t = new ObservableCollection<Object>();
            t.Add(new Object()); //potentially more objects
            properties.ItemsSource = t;
            PropertyPane.Content = properties;
        }        
    }
    public interface IProperty
    {
    }
    public class Component
    {
        public string name;
        private ObservableCollection<IProperty> propertyList;
        public ObservableCollection<IProperty> PropertyList
        {
            get
            {
                if (propertyList == null)
                    propertyList = new ObservableCollection<IProperty>();
                return propertyList;
            }
        }
    }
    public class Object
    {
        private ObservableCollection<Component> componentList;
        public ObservableCollection<Component> ComponentList 
        {
            get
            {
                if (componentList == null)
                    componentList = new ObservableCollection<Component>();
                return componentList;
            }
        }
    }
