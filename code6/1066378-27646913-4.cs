    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            List<PictureBox> pictureboxes = new List<PictureBox>();
            public Form1()
            {
                InitializeComponent();
            }
            private void AddPictureBox(string imagePath)
            {
                var pb = new PictureBox();
                pb.Name = "picturebox" + pictureboxes.Count;
                pb.Location = new Point(pictureboxes.Count * 100, 100);
                pb.Size = new Size(70, 70);
                pb.BorderStyle = BorderStyle.None;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(pb);
            
                pb.Image = Image.FromFile(imagePath);
                pb.Refresh();
                pb.MouseDown += new MouseEventHandler(picMouseDown);
                pb.MouseMove += new MouseEventHandler(picMouseMove);
                pb.MouseUp += new MouseEventHandler(picMouseUp);
                pictureboxes.Add(pb);
                Invalidate();
            }
            private void router_Click(object sender, EventArgs e)
            {
                AddPictureBox(@"D:\\router.jpg");
            }
            private void Form1_Load(object sender, EventArgs e)
            {
            }
            int x = 0;
            int y = 0;
            bool drag = false;
            private void picMouseDown(object sender, MouseEventArgs e)
            {
                // Get original position of cursor on mousedown
                x = e.X;
                y = e.Y;
                drag = true;
            }
            private void picMouseMove(object sender, MouseEventArgs e)
            {
                if (drag)
                {
                    PictureBox pb = (PictureBox)sender;
                    // Get new position of picture
                    pb.Top += e.Y - y;
                    pb.Left += e.X - x;
                    pb.BringToFront();
                    Invalidate();
                }
            }
            private void picMouseUp(object sender, MouseEventArgs e)
            {
                drag = false;
            }
            private void switch1_Click(object sender, EventArgs e)
            {
                AddPictureBox(@"D:\HP ProBook 450\Desktop\Grafika\switch1.png");
            }
            private void panel1_Paint(object sender, PaintEventArgs e)
            {
            }
            private void pc_Click(object sender, EventArgs e)
            {
                AddPictureBox(@"D:\HP ProBook 450\Desktop\pc.jpg");
            }
            private void server_Click(object sender, EventArgs e)
            {
                AddPictureBox(@"D:\HP ProBook 450\Desktop\server.png");
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                if (pictureboxes.Count > 1)
                {
                    var arr = pictureboxes.ToArray();
                    for (int i = 1; i < arr.Length; i++)
                    {
                        DrawLineBetween(e.Graphics, arr[i - 1], arr[i]);
                    }
                }
            }
            private void DrawLineBetween(Graphics g, PictureBox from, PictureBox to)
            {
                g.DrawLine(Pens.Black,
                    new Point(from.Left + from.Width / 2, from.Top + from.Height / 2),
                    new Point(to.Left + to.Width / 2, to.Top + to.Height / 2));
            }
        }
    }
