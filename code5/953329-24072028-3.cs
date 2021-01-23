	[Test]
	public void ShouldParseTitleOfSong()
	{
		// arrange
		var shazamService = new MockShazamService("<html><title>Bon Jovi - Shock to the Heart</title></html>");
		
		var parser = new ShazamMp3Parser(shazamService);
		
		// act
		var result = parser.Parse(new byte[0]); // doesn't matter
			
		// assert
		Assert.AreEqual("Bon Jovi - Shock to the Heart", result.Title);
	}
	
