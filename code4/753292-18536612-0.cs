    public partial class Form1 : Form
    {
        
        List<PictureBox> pictureBoxList = new List<PictureBox>();
        private bool isDragging = false;
        Point move;
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 3; i++)
            {
                PictureBox picture = new PictureBox
                {
                    Name = "pictureBox" + i,
                    Size = new Size(20, 20),
                    Location = new Point(i * 40, i * 40),
                    BorderStyle = BorderStyle.FixedSingle,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    ImageLocation = "A.jpg"
                };
                pictureBoxList.Add(picture);
            }
            foreach (PictureBox p in pictureBoxList)
            {
                    p.MouseDown += new MouseEventHandler(c_MouseDown);
                    p.MouseMove += new MouseEventHandler(c_MouseMove);
                    p.MouseUp += new MouseEventHandler(c_MouseUp);
                    pnlDisplayImage.Controls.Add(p);
                    pnlDisplayImage.Refresh();
             }
            
        }
        void c_MouseDown(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            isDragging = true;
            move = e.Location;
        }
        void c_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (isDragging == true) {
                Control c = sender as Control;
                for (int i = 0; i < pictureBoxList.Count(); i++)
                {
                    if (c.Equals(pictureBoxList[i]))
                    {
                        pictureBoxList[i].Left += e.X - move.X;
                        pictureBoxList[i].Top += e.Y - move.Y;
                    }
                }
            }
        }
        void c_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
    }
