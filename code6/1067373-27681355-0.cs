            foreach(Form child in this.MdiChildren)
            {
                if (child is FAnalysis)
                {
                    if (child.WindowState == FormWindowState.Minimized)
                    {
                        child.WindowState = FormWindowState.Normal;
                    }
                    child.BringToFront();
                    return; // stop looking and exit the method
                }
            }
            // no match was found; create a new child:
            FAnalysis fanalysis = new FAnalysis();
            fanalysis.MdiParent = this;
            fanalysis.Show();
            changeVisible(false, false, true, true, true, true);
