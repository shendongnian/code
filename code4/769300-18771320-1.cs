            int blockSize = 20;
            Panel[,] chessBoardPanels = new Panel[8, 8];
    
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ChessSquare sq = new ChessSquare(((char)(65+i)).ToString(), j);
                    sq.Color = (i + (j % 2)) % 2 == 0 ? Color.AliceBlue : Color.White;
                    Panel p = new Panel() 
                        {   Size = new Size(blockSize, blockSize), 
                            BackColor = sq.Color, 
                            Tag = sq,
                            Location = new Point(blockSize * i + 15, blockSize * j+15),
                        };
                    
                    p.MouseEnter+=new EventHandler(squareMouseEnter);
                    p.MouseLeave += new EventHandler(squareMouseLeave);
                        
                    chessBoardPanels[i, j] = p;
                    groupBox1.Controls.Add(p);
                }
            }
