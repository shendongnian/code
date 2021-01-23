    class Program
    {
        // Use string if you are okay with breaking the current pattern.
    	// private static string myDesign = "*";
        // Use char if you want to ensure the integrity of your pattern.
        private static char myDesign = '*';
    	private const int COLUMN_COUNT = 5;
    	private const int ROW_COUNT = 5;
    	private const int FIRST_ROW = 0;
    	private const int LAST_ROW = 4;
    	private const int FIRST_COLUMN = 0;
    	private const int LAST_COLUMN = 4;
    	static void Main(string[] args)
    	{
    		// Iterate through the desired amount of rows.
    		for (int row = 0; row < ROW_COUNT; row++)
    		{
    			// Iterate through the desired amount of columns.
    			for (int column = 0; column < COLUMN_COUNT; column++)
    			{
    				// If it is your first or last column or row, then write your character.
    				if (column == FIRST_COLUMN || column == LAST_COLUMN || row == FIRST_ROW || row == LAST_ROW)
    				{
    					Console.Write(myDesign);
    				}
    				// If anywhere in between provide your blank character.
    				else
    				{
    					Console.Write(" ");
    				}
    			}
    			Console.WriteLine("");
    		}
    		Console.Read();
    	}
    }
