    public PlateControl()
            {
                this.Size = new Size(600, 800);
                List<WellControl> plateWells = new List<WellControl>();
                int column = 1;
                int row = 0;
                for (int i = 1; i <= 96; i++)
                {
                    column = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(i / 8)));
                    row = i % 8;
                    WellControl newWell = new WellControl(i + 1);
                    newWell.Name = "wellControl" + i;
                    newWell.Location = new Point(column * 50, row * 50);
                    newWell.Size = new System.Drawing.Size(45, 45);
                    newWell.TabIndex = i;
                    newWell.WellSize = 45;
                    plateWells.Add(newWell);
                    newWell.Visible = true;
                }
                this.Controls.AddRange(plateWells.ToArray());
                InitializeComponent();
            }
