    public class Foo
    {
        public string Bar { get; set; }
        public string DontShowMe { get; set; }
    }
    public class FooMetadata
    {
        [DisplayName("Custom Bar")]
        public string Bar { get; set; }
        [Browsable(false)]
        public string DontShowMe { get; set; }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var type = typeof(Foo);
            var metadataType = typeof(FooMetadata);
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(type, metadataType), type);
            this.dataGridView1.DataSource = new List<Foo> { new Foo { Bar = "Foobar" } };
        }
    }
