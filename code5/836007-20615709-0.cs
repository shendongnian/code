        private void Form1_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath GP = new System.Drawing.Drawing2D.GraphicsPath();
            GP.AddEllipse(pic3.ClientRectangle);
            pic3.Region = new Region(GP);
        }
