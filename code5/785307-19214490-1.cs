    public partial class Form1 : Form
    {
        PictureBox pb = new PictureBox();
        NumericUpDown nud = new NumericUpDown();
        public Form1()
        {
            InitializeComponent();
            this.Text = "Inscribed Polygon Demo";
            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.RowCount = 2;
            tlp.RowStyles.Clear();
            tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tlp.ColumnCount = 2;
            tlp.ColumnStyles.Clear();
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlp.Dock = DockStyle.Fill;
            this.Controls.Add(tlp);
            Label lbl = new Label();
            lbl.Text = "Number of Sides:";
            lbl.TextAlign = ContentAlignment.MiddleRight;
            tlp.Controls.Add(lbl, 0, 0);
            nud.Minimum = 3;
            nud.Maximum = 20;
            nud.AutoSize = true;
            nud.ValueChanged += new EventHandler(nud_ValueChanged);
            tlp.Controls.Add(nud, 1, 0);
            pb.Dock = DockStyle.Fill;
            pb.Paint += new PaintEventHandler(pb_Paint);
            pb.SizeChanged += new EventHandler(pb_SizeChanged);
            tlp.SetColumnSpan(pb, 2);
            tlp.Controls.Add(pb, 0, 1);
        }
        void nud_ValueChanged(object sender, EventArgs e)
        {
            pb.Refresh();
        }
        void pb_SizeChanged(object sender, EventArgs e)
        {
            pb.Refresh();
        }
        void pb_Paint(object sender, PaintEventArgs e)
        {
            // make circle centered and 90% of PictureBox size:
            int Radius = (int)((double)Math.Min(pb.ClientRectangle.Width, pb.ClientRectangle.Height) / (double)2.0 * (double).9);
            Point Center = new Point((int)((double)pb.ClientRectangle.Width / (double)2.0), (int)((double)pb.ClientRectangle.Height / (double)2.0));
            Rectangle rc = new Rectangle(Center, new Size(1, 1));
            rc.Inflate(Radius, Radius);
            InscribePolygon(e.Graphics, rc, (int)nud.Value);
        }
        private void InscribePolygon(Graphics G, Rectangle rc, int numSides)
        {
            if (numSides < 3)
                throw new Exception("Number of sides must be greater than or equal to 3!");
            float Radius = (float)((double)Math.Min(rc.Width, rc.Height) / 2.0);
            PointF Center = new PointF((float)(rc.Location.X + rc.Width / 2.0), (float)(rc.Location.Y + rc.Height / 2.0));
            RectangleF rcF = new RectangleF(Center, new SizeF(1, 1));
            rcF.Inflate(Radius, Radius);
            G.DrawEllipse(Pens.Black, rcF);
            float Sides = (float)numSides;
            float ExteriorAngle = (float)360 / Sides;
            float InteriorAngle = (Sides - (float)2) / Sides * (float)180;
            float SideLength = (float)2 * Radius * (float)Math.Sin(Math.PI / (double)Sides);
            for (int i = 1; i <= Sides; i++)
            {
                G.ResetTransform();
                G.TranslateTransform(Center.X, Center.Y);
                G.RotateTransform((i - 1) * ExteriorAngle);
                G.DrawLine(Pens.Black, new PointF(0, 0), new PointF(0, -Radius));
                G.TranslateTransform(0, -Radius);
                G.RotateTransform(180 - InteriorAngle / 2);
                G.DrawLine(Pens.Black, new PointF(0, 0), new PointF(0, -SideLength));
            }
        }
    }
