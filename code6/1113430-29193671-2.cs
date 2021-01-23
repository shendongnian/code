	lineArray = File.ReadAllLines("Maze.txt");
	// Access one line at a time
	for (y = 0; y < lineArray.Count(); y++)
	{
		string line = lineArray[y];
		// Access each character in the file
		for (int x = 0 ; x < line.Count(); x++)
		{
			char c = line[x];
			string currentPosition = c.ToString();
			newFilePosition = Convert.ToInt32(currentPosition);
			if (newFilePosition == 1)
			{
				// Create a cube on the X axis
				NewCubePosition = new Vector3 (x, y, 0);
				Instantiate (g_mazeCubes, NewCubePosition, Quaternion.identity);
			}
		}
	}
