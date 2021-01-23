        public void RenderAllTabs()
        {
            foreach (TabPage tab in tabControlMain.TabPages)
            {
                tabControlMain.SelectTab(tab);
                using (Bitmap img = new Bitmap(tab.Width, tab.Height))
                {
                    tab.DrawToBitmap(img, tab.ClientRectangle);
                    img.Save(string.Format(@"C:\Tabs\{0}.png", tab.Text));
                }
            }
        }
