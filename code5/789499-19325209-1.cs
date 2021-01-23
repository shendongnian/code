    for (int i = 0; i < pbs.Length; i++) {
       pbs[i].Size = new Size(100, 100);
       pbs.Margin = new Padding(0, 0, 0, 60);
       pbs.Dock = DockStyle.Top;
       Panel p = i < 4 ? panel1 : panel2;
       p.Controls.Add(pbs[i]);
       pbs.BringToFront();
    }
