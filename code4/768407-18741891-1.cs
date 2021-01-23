            int numBlocks = 8;
            Panel[,] chessBoardPanels = new Panel[numBlocks, numBlocks];
            for (int iRow = 0; iRow < numBlocks; iRow++)
                for (int iColumn = 0; iColumn < numBlocks; iColumn++)
                {
                    Panel p = new Panel();
                    //set size
                    p.Size = new Size(50, 50);
                    //set back colour
                    p.BackColor = (iRow + (iColumn % 2)) % 2 == 0 ? Color.Black : Color.White;
                    //set location
                    p.Location = new Point(50 * iRow, 50 * iColumn);
                    chessBoardPanels[iRow, iColumn] = p;
                    this.Controls.Add(p);
                }
