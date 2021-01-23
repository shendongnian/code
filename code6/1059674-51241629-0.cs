    public class CustomArray<T>
    {
    	public T[] GetColumn(T[,] matrix, int columnNumber)
    	{
    		return Enumerable.Range(0, matrix.GetLength(0))
    				.Select(x => matrix[x, columnNumber])
    				.ToArray();
    	}
    	
    	public T[] GetRow(T[,] matrix, int rowNumber)
    	{
    		return Enumerable.Range(0, matrix.GetLength(1))
    				.Select(x => matrix[rowNumber, x])
    				.ToArray();
    	}
    }
