            int n = 16;
            int grid = (int)Math.Sqrt(n);
            int x = 0, y = 0;
            int yCounter = 0;
            int xCounter = 0;
            for (int i = 0; i < n; i++)
            {
                myGeometricObject[i] = new GeometricObject();
                if (i % grid == 0)
                {
                    y = yCounter * 50;
                    yCounter++;
                    xCounter = 0;
                }
                else
                {
                    xCounter++;
                }
                x = xCounter * 50;
                myGeometricObject[i].Location = new System.Drawing.Point(x, y);
                myGeometricObject[i].Size = new System.Drawing.Size(50, 50);
                this.Controls.Add(myGeometricObject[i]);
            }
