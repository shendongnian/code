        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                // open panel combination keys  Ctrl + F
                case (Keys.Control | Keys.F):
                    if (this.ultraDockManager1.ControlPanes["Your Pane Name"] != null)
                        if (this.ultraDockManager1.ControlPanes["Your Pane Name"].Pinned)
                        {
                            this.ultraDockManager1.ControlPanes["Your Pane Name"].Pinned = false;
                        }
                        else if (this.ultraDockManager1.ControlPanes["Your Pane Name"].IsInView)
                        {
                            this.ultraDockManager1.FlyIn(false);
                        }
                        else
                        {
                            // this.ultraDockManager1.ControlPanes["Your Pane Name"].Pin();
                            this.ultraDockManager1.ControlPanes["Your Pane Name"].Activate();
                        }
             }
        }
