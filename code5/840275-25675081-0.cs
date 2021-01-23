    namespace ConsoleApplication1
    {
	using GeoAPI.Geometries;
	using NetTopologySuite.Features;
	using NetTopologySuite.Geometries;
	using NetTopologySuite.IO;
	class Program
	{
		static void Main(string[] args)
		{
    		FeatureCollection features = new FeatureCollection();
			// Polygon 1
			List<Coordinate> coords = new List<Coordinate>();
			coords.Add(new Coordinate(0,0));
			coords.Add(new Coordinate(0,10));
			coords.Add(new Coordinate(10,10));
			coords.Add(new Coordinate(10,0));
 		   coords.Add(new Coordinate(0,0));
			LinearRing ring = new LinearRing(coords.ToArray());
			Polygon poly = new Polygon(ring);
			// Polygon1 attributes
			AttributesTable attr = new AttributesTable();
			attr.AddAttribute("Column1", "HELLO");
			attr.AddAttribute("Column2", "WORLD !");
			Feature featureForPolygon = new Feature(poly, attr);
			features.Add(featureForPolygon);
			ShapefileDataWriter writer = new ShapefileDataWriter(@"%userprofile%\documents\outFile");
			writer.Header = new DbaseFileHeader();
			writer.Header.AddColumn("Column1", 'C', 10, 0);
			writer.Header.AddColumn("Column2", 'C', 10, 0);
			writer.Write(features.Features);
		}
	}
    }
