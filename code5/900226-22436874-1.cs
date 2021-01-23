	// create and fill the list
	var tmpList = new List<Movie>();
	tmpList.Add(new Movie { VideoId = "1", Title = "Movie 1" });
	tmpList.Add(new Movie { VideoId = "2", Title = "Movie 2" });
	// create the collection
	var movies = new Movies 
				{ 
					Items = tmpList, 
					Custom = "yes" // fill the custom attribute
				};
	// serialize
	using (var writer = XmlWriter.Create(serializationFile, settings))
	{
		var serializer = new XmlSerializer(typeof(Movies));
		serializer.Serialize(writer, movies);
	}
