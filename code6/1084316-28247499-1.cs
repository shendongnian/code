    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CustomControl cc = new CustomControl();
            cc.Location = new Point(100, 100);
            cc.Size = new Size(300, 300);
            this.Controls.Add(cc);
        }
    }
