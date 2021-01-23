    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        List<Line> myLines {get;set;}
    
        private void Form1_Load(object sender, EventArgs e)
        {
            myLines = new List<Line>()
            {
                new Line() { Sku = "VCF001", Qty = 1 },
                new Line() { Sku = "VCF002", Qty = 1 },
                new Line() { Sku = "VCF003", Qty = 1 },
            };
            dataGridView1.DataSource = myLines;
        }
    
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = myLines.Where(l => l.Sku.ToLower().Contains(searchBox.Text.ToLower())).ToList();
           
        }
    }
    
    public class Line
    {
        public string Sku { get; set; }
        public int Qty { get; set; }
    }
