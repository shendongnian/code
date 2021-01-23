    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load( object sender, EventArgs e )
            {
                var list = new List<ItemX>() { 
                    new ItemX { Name = "a", Dictionary = new Dictionary<string, string> { { "1", "2" },{"qqq","wwww"} } },
                    new ItemX { Name = "b", Dictionary = new Dictionary<string, string> { { "3", "4" } } },
                    new ItemX { Name = "c", Dictionary = new Dictionary<string, string> { { "5", "6" } } },
                };
    
                comboBox1.DataSource = list;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Dictionary";
            }
    
            private void button1_Click( object sender, EventArgs e )
            {
                if ( comboBox1.SelectedValue != null )
                {
                    var d = comboBox1.SelectedValue as Dictionary<string, string>;
    
                    if ( d != null )
                    {
                        var builder = new StringBuilder();
                        
                        foreach ( KeyValuePair<string, string> p in d )
                        {
                            builder.AppendFormat( "key:{0} value:{1}\n", p.Key, p.Value );
                        }
    
                        MessageBox.Show( builder.ToString() );
                    }
                }
            }
        }
    
        public class ItemX
        {
            public string Name { get; set; }
            public Dictionary<string, string> Dictionary { get; set; }
        }
    }
