    class RandomGameBoard
    {
    	struct Position
    	{
    		public int Column;
    		public int Row;
    
    		public Position(int column, int row)
    		{
    			Column = column;
    			Row = row;
    		}
    	}
    
    	private const int ROWS = 4, COLUMNS = 4;
    
    	private static char[,] GenerateRandomBoard(int columns, int rows)
    	{
    		char[,] board = new char[rows, columns];
    		List<Position> positions = new List<Position>((columns + 1) * (rows + 1));
    
    		for (int row = 0; row < rows; row++)
    		{
    			for (int column = 0; column < columns; column++)
    			{
    				board[column, row] = '.';
    				positions.Add(new Position(column, row));
    			}
    		}
    
    		Random random = new Random();
    		foreach (char item in "EDPPPG")
    		{
    			int index = random.Next(positions.Count);
    			Position position = positions[index];
    			board[position.Column, position.Row] = item;
    			positions.RemoveAt(index);
    		}
    
    		return board;
    	}
    
    	public static void Execute()
    	{
    		char[,] board;
    		board = GenerateRandomBoard(COLUMNS, ROWS);
    		board = GenerateRandomBoard(COLUMNS, ROWS);
    		board = GenerateRandomBoard(COLUMNS, ROWS);
    	}
    }
