        private void Legacy_ResizeBegin(object sender, EventArgs e)
        {
            //By changing the this properties, the form, somehow, don't loose the hittest..
            panelTransparent.BackColor = Color.WhiteSmoke;
            this.TransparencyKey = Color.WhiteSmoke;
        }
        private void Legacy_ResizeEnd(object sender, EventArgs e)
        {
            panelTransparent.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
        }
