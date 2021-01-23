    var lineArray = File.ReadAllLines("Maze.txt");
    
    for (var y = 0; y < lineArray.Length; y++)
    {
    	foreach (var c in lineArray[y].ToCharArray()
                                      .Select((value, i) => new { Character = value, Index = i })
                                      .Where(x => Convert.ToInt32(x.Character) == 1))
    	{
    		Instantiate(g_mazeCubes, new Vector3(c.Index, y, 0), Quaternion.identity);
    	}
    }
