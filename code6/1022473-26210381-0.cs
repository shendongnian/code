        bool bIsLoaded = false;
        private void Form1_Activated(object sender, EventArgs e)
        {
            if (!bIsLoaded)
            {
                this.WindowState = FormWindowState.Maximized;
                bIsLoaded = true;
            }
        }
