    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication3
    {
        public partial class CaptureScreen : Form
        {
            public Image Image { get; set; }
    
            private Rectangle selection;
            private Rectangle previousselection;
            private Point startPoint;
    
            public static Image Snip()
            {
                using (var bmp = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb))
                {
                    using (var graphics = Graphics.FromImage(bmp)) graphics.CopyFromScreen(SystemInformation.VirtualScreen.Left, SystemInformation.VirtualScreen.Top, 0, 0, bmp.Size);
                    using (var snipper = new CaptureScreen(bmp, new Point(SystemInformation.VirtualScreen.Left, SystemInformation.VirtualScreen.Top)))
                    {
                        if (snipper.ShowDialog() == DialogResult.OK) return snipper.Image;
                    }
                    return null;
                }
            }
    
            public CaptureScreen(Image screenShot, Point startPos)
            {
                InitializeComponent();
    
                Cursor = Cursors.Cross;
                BackgroundImage = screenShot;
                ShowInTaskbar = false;
                FormBorderStyle = FormBorderStyle.None;
                StartPosition = FormStartPosition.Manual;
                Size = screenShot.Size;
                Location = startPos;
                SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            }
    
            protected override void OnMouseDown(MouseEventArgs e)
            {
                if (e.Button != MouseButtons.Left) return;
                startPoint = e.Location;
                selection = new Rectangle(e.Location, new Size(0, 0));
                previousselection = selection;
                Invalidate();
            }
    
            protected override void OnMouseMove(MouseEventArgs e)
            {
                if (e.Button != MouseButtons.Left) return;
                var x1 = Math.Min(e.X, startPoint.X);
                var y1 = Math.Min(e.Y, startPoint.Y);
                var x2 = Math.Max(e.X, startPoint.X);
                var y2 = Math.Max(e.Y, startPoint.Y);
                Invalidate(previousselection); // invalidate old rect area so it gets blanked out
                previousselection = selection;
                selection = new Rectangle(x1, y1, x2 - x1, y2 - y1);
                Invalidate(selection); // invalidate new rect area so it gets drawn
            }
    
            protected override void OnMouseUp(MouseEventArgs e)
            {
                if (selection.Width <= 0 || selection.Height <= 0) return;
                Image = new Bitmap(selection.Width, selection.Height);
                using (var gr = Graphics.FromImage(Image))
                {
                    gr.DrawImage(BackgroundImage, new Rectangle(0, 0, Image.Width, Image.Height),
                        selection, GraphicsUnit.Pixel);
                }
                DialogResult = DialogResult.OK;
            }
    
            protected override void OnPaint(PaintEventArgs e)
            {
                using (var br = new SolidBrush(Color.FromArgb(127, Color.White)))
                using (var pen = new Pen(Color.Red, 1))
                {
                    Region region = new Region(new Rectangle(0,0,Width,Height));
                    region.Exclude(selection);
                    region.Intersect(e.ClipRectangle);
                    e.Graphics.FillRegion(br, region);
                    e.Graphics.DrawRectangle(pen, selection.X, selection.Y, selection.Width - 1, selection.Height - 1);
                }
            }
        }
    }
