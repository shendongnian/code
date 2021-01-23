    public partial class Form1 : Form
    {
        public delegate void AddToControl(Control control);
        public AddToControl MyAddToControl;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread((ThreadStart)delegate
                                                    {
                                                        CreateControl c = new CreateControl();
                                                        Panel p = (Panel)c.Create("panel_1", new Point(10, 10), new Size(100, 100));
                                                        AddControlToControls(this, p);
                                                    });
            t1.Start();
        }
        public void AddControlToControls(Control parent, Control control)
        {
            MyAddToControl = new AddToControl(this.AddControl);
            parent.Invoke(this.MyAddToControl, control);
        }
        public void AddControl(Control control)
        {
            this.Controls.Add(control);
        }
    }
