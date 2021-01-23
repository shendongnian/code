    ExPanel hrvPanel = new ExPanel(150);
            System.Collections.ArrayList hrvColl = pnlColl; //Panel collection list gets from a Method            
            if (hrvColl.Count == 0)
                return;
            int splits = 0;
            for (int p = hrvColl.Count - 1; p >= 0; p--)
            {
                ExPanel hrv = hrvColl[p] as ExPanel;
                hrv.Height = hrv.PreferredHeight;
                hrvPanel.Controls.Add(hrv);
                //Adding splliter
                if (splits < hrvColl.Count - 1)
                {
                    Splitter splitGrid = new Splitter();
                    splitGrid.Dock = DockStyle.Top;
                    hrvPanel.Controls.Add(splitGrid);
                    splits++;
                }
            }
            hrvPanel.Dock = DockStyle.Top;
