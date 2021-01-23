        // Load property pages
            try
            {
                mnuPropertyPages.MenuItems.Clear();
                for (int c = 0; c < capture.PropertyPages.Count; c++)
                {
                    p = capture.PropertyPages[c];
                    m = new MenuItem(p.Name + "...", new EventHandler(mnuPropertyPages_Click));
                    mnuPropertyPages.MenuItems.Add(m);
                }
                mnuPropertyPages.Enabled = (capture.PropertyPages.Count > 0);
            }
            catch { mnuPropertyPages.Enabled = false; }
