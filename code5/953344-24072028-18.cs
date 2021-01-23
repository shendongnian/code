	[Test]
	public void ShouldParseTitleOfSong()
	{
		// arrange
		var mockShazamService = new Mock<IShazamService>();
		
		mockShazamService.Setup(x => x.IdentifySong(It.IsAny<byte[]>()))
		                 .Returns("<html><title>Bon Jovi - Shock to the Heart</title></html>");
						 
		var parser = new ShazamMp3Parser(mockShazamService.Object);
		
		// act
		var result = parser.Parse(new byte[0]);
			
		// assert
		Assert.AreEqual("Bon Jovi - Shock to the Heart", result.Title);
	}
