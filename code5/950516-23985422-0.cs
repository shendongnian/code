            SolidColorBrush s = btn.Foreground as SolidColorBrush;
            string name="";
            foreach (KnownColor kc in Enum.GetValues(typeof(KnownColor)))
            {
                System.Drawing.Color known = System.Drawing.Color.FromKnownColor(kc);
                if (System.Drawing.Color.FromArgb(s.Color.A, s.Color.R, s.Color.G, s.Color.B).ToArgb() == known.ToArgb())
                {
                    name = known.Name;
                }
            }
            MessageBox.Show(name);
