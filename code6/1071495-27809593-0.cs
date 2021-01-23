	var rnd = new Random();
	
	var pieces =
		from p in Enum.GetValues(typeof(EnumChestPiece)).Cast<EnumChestPiece>()
		from c in Enum.GetValues(typeof(EnumColor)).Cast<EnumColor>()
		orderby rnd.Next()
		select new
		{
			Piece = p,
			Color = c,
		};
		
	foreach (var p in pieces.Take(3))
	{
		Console.WriteLine("{0} {1}", p.Color, p.Piece);
	}
