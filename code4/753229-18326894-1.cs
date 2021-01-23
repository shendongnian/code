		public void initiateArray()
		{
			Cell[,] Map1 = new Cell[4, 4];
			foreach(var row in Enumerable.Range(0, Map1.GetLength(0)))
			foreach(var column in Enumerable.Range(0, Map1.GetLength(1)))
			{
					Map1[row, column] = new Cell();			
			}
			Map1[0, 0] = new Cell(true, false, false, true);
			Map1[0, 1] = new Cell(false, false, false, true);
		}
