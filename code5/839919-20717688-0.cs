    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            GraphicsPath path = new GraphicsPath();
            RectangleF pathRect;
            public Form1()
            {
                InitializeComponent();
                Location = new Point(0, 0);
                Size = new System.Drawing.Size(500, 500);
                
                Label lbl1 = new Label();
                lbl1.Location = new Point(100, 100);
                lbl1.Size = new System.Drawing.Size(200, 100);
                lbl1.BorderStyle = BorderStyle.FixedSingle;
                lbl1.Paint += new PaintEventHandler(lbl_Paint);
                Label lbl2 = new Label();
                lbl2.Location = new Point(300, 200);
                lbl2.Size = new System.Drawing.Size(100, 200);
                lbl2.BorderStyle = BorderStyle.FixedSingle;
                lbl2.Paint += new PaintEventHandler(lbl_Paint);
                Controls.Add(lbl1);
                Controls.Add(lbl2);
                path.AddRectangle(new Rectangle(50, 50, 150, 150));
                path.AddEllipse(new Rectangle(25, 50, 25, 50));
                pathRect = path.GetBounds();
            }
            void lbl_Paint(object sender, PaintEventArgs e)
            {
                var rect = ((Control)sender).DisplayRectangle;
                PointF[] plgpts = new PointF[] {
                    new PointF(rect.Left, rect.Top),
                    new PointF(rect.Right - 1, rect.Top),
                    new PointF(rect.Left, rect.Bottom - 1),
                };
                Graphics g = e.Graphics;
                g.Clear(SystemColors.Control);
                Matrix matrix = new Matrix(path.GetBounds(), plgpts);
                g.Transform = matrix;
                g.DrawPath(Pens.Red, path);
            }
        }
    }
