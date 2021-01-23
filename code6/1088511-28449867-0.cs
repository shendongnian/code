    public partial class Form1 : Form
    {
        private Form2 form2;
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(200, 200);
            form2 = new Form2();
            form2.StartPosition = this.StartPosition;
            form2.Location = this.Location;
            form2.Show();
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
            this.LocationChanged += new EventHandler(Form1_LocationChanged);
            this.SizeChanged += new EventHandler(Form1_SizeChanged);
        }
        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            form2.Close();
        }
        void Form1_LocationChanged(object sender, EventArgs e)
        {
            form2.Location = this.Location;
        }
        void Form1_SizeChanged(object sender, EventArgs e)
        {
            form2.Size = this.Size;
        }
    }
