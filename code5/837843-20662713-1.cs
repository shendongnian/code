	var mapObjects = JsonObject.Parse(request.MapObjects);
	foreach(var overlay in mapObjects.ArrayObjects("overlays"))
	{
		if(overlay.Get("type")=="polygon")
		{
			foreach(var pathPart in overlay.JsonTo<Point[][]>("paths"))
			{
				foreach(var pathItem in pathPart)
				{
					Console.WriteLine(pathItem.lat);
					Console.WriteLine(pathItem.lng);
				}
			}
		}
	}
