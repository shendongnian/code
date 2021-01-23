    public partial class Form1 : Form
    {
        List<Label> labels;
        public Form1()
        {
            InitializeComponent();
            this.labels=new List<Label>();
            AddLabelsToFrom(20);
        }
        void AddLabelsToFrom(int count)
        {
            for (int i=0; i<count; i++)
            {
                var lbl=new Label() { Name="lbl"+i, Height=50, Width=200, MinimumSize=new Size(200, 50), BorderStyle=System.Windows.Forms.BorderStyle.Fixed3D, Text="Label "+i };
                labels.Add(lbl);
                flowLayoutPanel1.Controls.Add(lbl);
            }
        }
    }
