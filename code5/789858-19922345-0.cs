    using ClipperLib;
    
	using Path = List<IntPoint>;
    using Paths = List<List<IntPoint>>;
	static Polygon IntsToPolygon(Int64[] ints)
	{
	  int len1 = ints.Length / 2;
	  Polygon result = new Polygon(len1);
	  for (int i = 0; i < len1; i++)
		result.Add(new IntPoint(ints[i * 2], ints[i * 2 + 1]));
	  return result;
	}
	
	static void Main(string[] args)
	{
		Paths clip = new Paths(); //clipping polygon(s)
		//make a polygon in the shape of a pentagram
		//with center (200,200) and radius 100 ...
		Int64[][] ints1 = new Int64[][] 
		{
		new Int64[]{222, 169, 295, 169, 236, 212, 259, 281, 200, 238, 
		  141, 281, 164, 212, 105, 169, 178, 169, 200, 100}
		};
		clip.Add(IntsToPolygon(ints1[0]));
		Paths subj = new Paths(); //subject paths, could be open or closed here
		int gridWidth = 5;
		int loopCnt = 200 / gridWidth;
		//now make grid lines and add them to subj ready for clipping ...
		//add horizontal grid lines ...
		for (int i = 0; i <= loopCnt; i++)
		{
		Path gridLine = new Path(2);
		gridLine.Add(new IntPoint(100, 100 + i * gridWidth));
		gridLine.Add(new IntPoint(300, 100 + i * gridWidth));
		subj.Add(gridLine);
		}
		//add vertical grid lines ...
		for (int i = 0; i <= loopCnt; i++)
		{
		Path gridLine = new Path(2);
		gridLine.Add(new IntPoint(100 + i * gridWidth, 100));
		gridLine.Add(new IntPoint(100 + i * gridWidth, 300));
		subj.Add(gridLine);
		}
		
		//now clip the gridlines (subj) with the pentagram (clip) ...
		Clipper c = new Clipper();
		PolyTree solution = new PolyTree();
		c.AddPaths(subj, PolyType.ptSubject, false); //ie paths NOT closed
		c.AddPaths(clip, PolyType.ptClip, true); //nb: clip paths MUST be closed
		c.Execute(ClipType.ctIntersection, 
		  solution, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd);
		Paths clippedGrids = Clipper.PolyTreeToPaths(solution);
	
		//Display the result (sorry, make your own display function) ...
		//Display(Paths p, Color stroke, Color brush, PolyFillType pft, bool IsClosed) 
		Display(subj, Color.FromArgb(0x18, 0, 0, 0x9c), 
			Color.Blue, PolyFillType.NonZero, false); //unclipped grid
		Display(clippedGrids, FromArgb(0, 0, 0, 0), 
			Color.Red, false); //clipped grid 
		
	}
