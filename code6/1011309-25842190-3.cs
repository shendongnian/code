    public static void WriteCSVData<T, TValue>(this T[,] data, StreamWriter sw, 
        Func<T,TValue> func)
	{
		for (int row = 0; row < data.GetLength(0); row++)
			for (int col = 0; col < data.GetLength(1); col++)
			{
				string s = func(data[row, col]).ToString();
	
				if (s.Contains(","))
					sw.Write("\"" + s + "\"");
				else
					sw.Write(s);
	
				if (col < data.GetLength(1) - 1)
					sw.Write(",");
				else
					sw.WriteLine();
			}
	}
