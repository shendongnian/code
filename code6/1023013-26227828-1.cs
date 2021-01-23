    class Csv
    {
        // Maps the column names to indices
    	Dictionary<String, int> columns = new Dictionary<String, int>();
        // Store rows as arrays of fields
    	List<String[]> rows = new List<String[]>()
    	
    	public Csv(String[] lines)
    	{
    		String[] headerRow = lines[0].Split(',');
    		
    		for (int x = 0; x < headerRow.Length; x += 1)
    		{
                // Iterate through first row to get the column names an map to the indices
                String columnName = headerRow[x];
    			columns[columnName] = x;
    		}
    		
    		for (int x = 1; x < lines.Length - 1; x += 1)
    		{
                // Iterate through rows splitting them into each field and storing in 'rows' variable
    			rows.Add(lines[x].Split(','); // Not properly escaping (e.g. address could have "Memphis, Tn")
    		}
    	}
    	
        // Method to get a field by row index and column name
    	public Get(int rowIndex, String columnName)
    	{
    		int columnIndex = columns[columnName];
    		
    		return rows[rowIndex][columnIndex];
    	}
    }
