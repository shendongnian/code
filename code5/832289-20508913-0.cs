        private void button1_Click(object sender, EventArgs e)
        {
            svnPathCheck_lbl.Text = "Checking...";
            svnPathCheck_lbl.Visible = true;
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_WorkCompleted;
            bw.RunWorkerAsync();
        }
        private void bw_WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            svnPathCheck_lbl.Text = "Work completed";
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            string svnValidity = getCMDOutput("svn info " + SVNPath_txtbox.Text);
            Match match = Regex.Match(svnValidity, @"Revision:\s+([0-9]+)", RegexOptions.IgnoreCase);
        }
