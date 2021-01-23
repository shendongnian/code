    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public partial class Form1 : Form
    {
        // X, Y scaling variables for btn1
        private float _btn1xScale;
        private float _btn1yScale;
        public Form1()
        {
            InitializeComponent();
            // The scale is really the % of btn X & Y along image width and height:
            // Calculate X and Y scale from initial location and position in image
            // Has to happen AFTER InitializeComponent is called!
            _btn1xScale = btn1.Location.X / (float)pictureBox1.Width;
            _btn1yScale = btn1.Location.Y / (float)pictureBox1.Height;
        }
        private void pictureBoxResize(object sender, EventArgs e)
        {
            // adjust position based on 
            btn1.Location = new Point(
                (int)(pictureBox1.Width * _btn1xScale), 
                (int)(pictureBox1.Height * _btn1yScale));
        }
    }
