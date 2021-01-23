    var lineArray = File.ReadAllLines("Maze.txt");
    
    foreach (string line in lineArray)
    {
    	int x = 0;
    
    	foreach (var c in line.Where(i => Convert.ToInt32(i) == 1))
    	{
    		var NewCubePosition = new Vector3(x, y, 0);
    		Instantiate(g_mazeCubes, NewCubePosition, Quaternion.identity);
    
    		x++;
    	}
    
    	y++;
    }
