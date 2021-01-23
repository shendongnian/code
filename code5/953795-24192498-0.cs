         using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Rectangle_Utility
    {
        public partial class Form1 : Form
        {
            Point startPos;
            Point currentPos;
            bool drawing;
            List<Rectangle> myRectangles = new List<Rectangle>();
    
            public Form1()
            {
                InitializeComponent();
                this.DoubleBuffered = true;
            }
    
            #region Menu Tool Strip
            private void selectFileToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    //Initiate new OpenFileDialog
                    //Filter for img and bmp files
                    //Start looking in root of c:
                    OpenFileDialog myFile = new OpenFileDialog();
                    myFile.Filter = "Image Files(*.img, *.bmp) |*.img; *.bmp;";
                    myFile.InitialDirectory = "c:\\";
    
                    //Set background image of pictureBox to file selected through OpenFileDialog
                    if (myFile.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.BackgroundImage = Image.FromFile(myFile.FileName);
    
                    }
                }
    
                catch (Exception error)
                {
                    MessageBox.Show("Error loading the selected file.  Original error: " + error.Message);
                    
                }
            }
    
            private void exitToolStripMenuItem_Click(object sender, EventArgs e)
            {
                this.Close();
            }
    
            private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
            {
                
            }
    
            private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
            {
    
            }
    
            private void undoLastActionToolStripMenuItem_Click(object sender, EventArgs e)
            {
    
            }
    
            private void redoLastActionToolStripMenuItem_Click(object sender, EventArgs e)
            {
    
            }
            #endregion
    
            #region Rectangle
    
            private Rectangle getRectangle()
            {
                return new Rectangle(
                    Math.Min(startPos.X, currentPos.X),
                    Math.Min(startPos.Y, currentPos.Y),
                    Math.Abs(startPos.X - currentPos.X),
                    Math.Abs(startPos.Y - currentPos.Y));
            }
    
            private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    currentPos = startPos = e.Location;
                    drawing = true;
                }
                
            }
    
            private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
            {
                currentPos = e.Location;
                if (drawing) pictureBox1.Invalidate();
            }
    
            private void pictureBox1_Paint(object sender, PaintEventArgs e)
            {
                if (myRectangles.Count > 0) e.Graphics.DrawRectangles(Pens.Black, myRectangles.ToArray());
                if (drawing) e.Graphics.DrawRectangle(Pens.Red, getRectangle());
            }
    
            private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
            {
                if (drawing)
                {
                    drawing = false;
                    var rect = getRectangle();
                    if (rect.Width > 0 && rect.Height > 0) myRectangles.Add(rect);
                    pictureBox1.Invalidate();
                }
            }
    
            #endregion
    
        }
    }
