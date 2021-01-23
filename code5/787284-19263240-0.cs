            int tabCount = 0;
            foreach (TabPage tp in customTabControl1.TabPages)
            {
                tp.Tag = tabCount;
                foreach (Control ctrl in tp.Controls)
                {
                    if (ctl is YourUserControlTypeHere)
                    {
                        YourUserControlTypeHere uc = (YourUserControlTypeHere)ctl;
                        uc.BrowserCount = TabCount; // Error Unknown member BrowserCount
                    }
                }
            }
    
