	struct Q
	{
		public int X, Y, Z;
	}
	public static int bfs(int[, ,] matrix)
	{
		int d1 = matrix.GetLength(0), d2 = matrix.GetLength(1), d3 = matrix.GetLength(2);
		var visited = new bool[d1, d2, d3];
		int sum = 0;
		var q = new List<Q>();
		q.Add(new Q());
		while (q.Count > 0)
		{
			var last = q[q.Count - 1];
			q.RemoveAt(q.Count - 1);
			int cx = last.X;
			int cy = last.Y;
			int cz = last.Z;
			sum += matrix[cx, cy, cz];
			int x, y, z;
			if ((x = cx - 1) >= 0 && !visited[x, cy, cz])
			{ q.Add(new Q{X = x, Y = cy, Z = cz}); visited[x, cy, cz] = true; 
    ...
