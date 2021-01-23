    [Designer(typeof(TestUserControlDesigner))]
    public partial class TestPanel3 : UserControl
    {
        private Panel innerPanel = new Panel();
        public TestPanel3()
        {
            InitializeComponent();
            this.Controls.Add(innerPanel);
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ContentPanel
        {
            get { return innerPanel; }
        }
    }
    internal class TestUserControlDesigner : ParentControlDesigner
    {
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);
            EnableDesignMode((this.Control as TestPanel3).ContentPanel, "ContentPanel");
        }
    }
