     public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            TableLayoutPanel myTable = new TableLayoutPanel();
            myTable.Location = new Point(0, 0);
            myTable.Size = new Size(506, 417);
            myTable.AutoSize = true;
            myTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            myTable.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddRows;
            myTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            this.Controls.Add(myTable);
            Panel panel1 = new Panel();
            Panel panel2 = new Panel();
            Panel panel3 = new Panel();
            Panel panel4 = new Panel();
           
            panel1.BackColor = Color.Red;          
            panel2.BackColor = Color.Black;           
            panel3.BackColor = Color.Blue;
            panel4.BackColor = Color.Yellow;
            myTable.Controls.Add(panel1, 0, 0);
            myTable.Controls.Add(panel2, 0, 1);
            myTable.Controls.Add(panel3, 0, 2);
            myTable.Controls.Add(panel4, 0, 3);
        }
    }
