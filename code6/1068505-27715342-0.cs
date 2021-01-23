    private void novinky_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            domu.Visible = true;
            domu_clicked.Visible = false;
            novinky.Visible = false;
            this.BackgroundImage = posteruslauncher.Properties.Resources.background_novinky;
            this.ResumeLayout();
        }
