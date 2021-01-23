        private void button1_Click(object sender, EventArgs e)
        {
            var wov = new WOView();
            gradientPanel1.Controls.Add(wov);
            wov.Visible = true;
            wov.Location=new Point(0,0);
            //wov.Dock = DockStyle.Fill;
        }
