    [Feature(typeof(myDefaults))]
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        public class myDefaults : DefaultInitializer
        {
            public override void InitializeDefaults(ModelItem item)
            {
                item.Name = "test";
            }
        }
    }
