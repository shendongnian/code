     List<Control> controlsNeed = getUserControls();
            int PaddingTop = 10;
            foreach (Control c in controlsNeed)
            {
                this.Controls.Add(c);
                c.Location = new Point(0, c.Height + PaddingTop);
            }
