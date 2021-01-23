    public struct Edge
    {
        public Edge()
        {
            this.Visited = false;
        }
        public Point[] Points;
        public bool Visited;
    }
    public static int PolygonSearch(Point start, Point end, List<Point> visitedPoints, List<Edge> unvisitedEdges)
    {
        int count = 0;
        for (int i = unvisitedEdges.Count - 1; i > -1; i--)
        {
            Edge line = unvisitedEdges[i];
            if (((Equal(line.Points[0], start) && Equal(line.Points[1], end)) 
                || (Equal(line.Points[1], start) && Equal(line.Points[0], end))) 
                && visitedPoints.Count > 2
                && line.Visited == false)
            {
                return count + 1;
            }
            else if (Equal(start, line[0]))
            {
                unvisitedEdges[i].Visited = true;
                count += PolygonSearch(line.Points[1], end, visitedPoints, unvisitedEdges);
            }
            else if (Equal(start, line[0]))
            {
                unvisitedEdges[i].Visited = true;
                count += PolygonSearch(line.Points[1], end, visitedPoints, unvisitedEdges);
            }
        }
        return count;
    }
