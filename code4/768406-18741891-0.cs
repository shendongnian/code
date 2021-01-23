            int numBlocks = 8;
            Panel[,] chessBoardPanels = new Panel[numBlocks, numBlocks];
            for (int iRow = 0; iRow < numBlocks; iRow++)
                for (int iColumn = 0; iColumn < numBlocks; iColumn++)
                {
                    Panel p = new Panel();
                    //set location
                    //set size
                    //set back colour
                    chessBoardPanels[iRow, iColumn] = p;
                    this.Controls.Add(p);
                }
