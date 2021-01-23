    for (int i = 0; i < pbs.Length; i++)
                {
                    progressbars[i] = new ProgressBar();
                    progressbars[i].Size = new Size(100, 10);
                    progressbars[i].Margin = new Padding(0, 0, 0, 70);
                    progressbars[i].Dock = DockStyle.Top;
                    pbs[i] = new PictureBox();
                    pbs[i].MouseEnter += globalPbsMouseEnterEvent;
                    pbs[i].MouseLeave += globalPbsMouseLeaveEvent;
                    pbs[i].Tag = "PB" + i.ToString();
                    pbs[i].Size = new Size(100, 100);
                    pbs[i].Margin = new Padding(0, 0, 0, 60);
                    pbs[i].Dock = DockStyle.Top;
                    pbs[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    Panel p = i < 4 ? panel1 : panel2;
                    p.Controls.Add(pbs[i]);
                    p.Controls.Add(progressbars[i]);
                    pbs[i].BringToFront();
                    progressbars[i].BringToFront();
                }
