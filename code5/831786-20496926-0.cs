    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private Button button1;
            private PictureBox pictureBox1;
            private Bitmap bmp;
            private Point? p1 = null;
            
    
            public Form1()
            {
                InitializeComponent();
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.FillRectangle(Brushes.White, 0, 0, bmp.Width, bmp.Height);
                }
    
                pictureBox1.Image = bmp;
            }
    
            private void InitializeComponent()
            {
                this.pictureBox1 = new System.Windows.Forms.PictureBox();
                this.button1 = new System.Windows.Forms.Button();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                this.SuspendLayout();
                // 
                // pictureBox1
                // 
                this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.pictureBox1.Location = new System.Drawing.Point(0, 23);
                this.pictureBox1.Name = "pictureBox1";
                this.pictureBox1.Size = new System.Drawing.Size(477, 352);
                this.pictureBox1.TabIndex = 0;
                this.pictureBox1.TabStop = false;
                this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
                this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
                this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
                this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
                // 
                // button1
                // 
                this.button1.Dock = System.Windows.Forms.DockStyle.Top;
                this.button1.Location = new System.Drawing.Point(0, 0);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(477, 23);
                this.button1.TabIndex = 1;
                this.button1.Text = "write bitmap to file";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click);
                // 
                // Form1
                // 
                this.ClientSize = new System.Drawing.Size(477, 375);
                this.Controls.Add(this.pictureBox1);
                this.Controls.Add(this.button1);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.Name = "Form1";
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                this.ResumeLayout(false);
    
            }
    
    
    
            private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
            {
                p1 = pictureBox1.PointToClient(MousePosition);
            }
    
            private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
            {
                Point p2 = pictureBox1.PointToClient(MousePosition);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawLine(Pens.Black, p1.Value, pictureBox1.PointToClient(MousePosition));
                }
                p1 = null;
                pictureBox1.Invalidate();
            }
    
            private void pictureBox1_Paint(object sender, PaintEventArgs e)
            {
                if (p1 != null)
                {
                    e.Graphics.DrawLine(Pens.Black, p1.Value, pictureBox1.PointToClient(MousePosition));
                }
            }
    
            private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
            {
                pictureBox1.Invalidate();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                var dialog=new SaveFileDialog();
                dialog.DefaultExt = "bmp";
                dialog.ValidateNames = true;
                dialog.Filter = "Bitmap|*.bmp";
                dialog.AddExtension = true;
                dialog.OverwritePrompt=true;
                var result=dialog.ShowDialog(this);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    using (var fs = dialog.OpenFile())
                    {
                        bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                }
            }
    
            
        }
    }
