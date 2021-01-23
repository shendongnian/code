      public class myItem
        {
            public string ItemName { get; set; }
            public object Value { get; set; }
        }
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                List<myItem> s = new List<myItem>();
                s.Add(new myItem()
                {
                    ItemName = "ItemA",
                    Value = (object)"BB"
                });
    
    
                comboBox1.DataSource = s;
                comboBox1.DisplayMember = "ItemName";
                comboBox1.ValueMember = "Value";
            }
        }
