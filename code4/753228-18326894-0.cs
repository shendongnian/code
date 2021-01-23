		public void initiateArray()
		{
			Cell[,] Map1 = new Cell[4, 4];
			for (int row = 0; row < Map1.GetLength(0); row++)
			{
				for (int column = 0; column < Map1.GetLength(1); column++)
				{
					Map1[row, column] = new Cell();
				}
			}
			Map1[0, 0] = new Cell(true, false, false, true);
			Map1[0, 1] = new Cell(false, false, false, true);
		}
		
