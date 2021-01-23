	[Test]
	public void ShouldParseTitleOfSong()
	{
		// arrange
		var shazamService = new MockShazamService(
			"<html><title>Bon Jovi - Shock to the Heart</title></html>");
		
		var parser = new ShazamMp3Parser(shazamService);
		
		// act
		// this is just dummy input, 
		// we're not testing input in this specific test
		var result = parser.Parse(new byte[0]);
			
		// assert
		Assert.AreEqual("Bon Jovi - Shock to the Heart", result.Title);
	}
	
