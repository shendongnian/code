            public static System.Data.Spatial.DbGeography GetClosestPointOnRoute(System.Data.Spatial.DbGeography line, System.Data.Spatial.DbGeography point)
        {
            SqlGeography sqlLine = SqlGeography.Parse(line.AsText()).MakeValid(); //the linestring
            SqlGeography sqlPoint = SqlGeography.Parse(point.AsText()).MakeValid(); //the point i want on the line
            SqlGeography shortestLine = sqlPoint.ShortestLineTo(sqlLine); //find the shortest line from the linestring to point
            //lines have a start, and an end
            SqlGeography start = shortestLine.STStartPoint();
            SqlGeography end = shortestLine.STEndPoint();
            DbGeography newGeography = DbGeography.FromText(end.ToString(), 4326);
            var distance = newGeography.Distance(line);
            return newGeography;
        }
