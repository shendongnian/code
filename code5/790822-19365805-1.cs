    [Test]
    public async Task downloads_content_for_each_url()
    {
      _mockGetContentUrls.Setup(x => x.GetAll())
        .Returns(new[] { "http://www.url1.com", "http://www.url2.com" });
      _mockDownloadContent.Setup(x => x.DownloadContentFromUrlAsync(It.IsAny<string>()))
        .Returns(Task.FromResult<IEnumerable<MobileContent>>(new List<MobileContent>()));
      var downloadAndStoreContent= new DownloadAndStoreContent(
        _mockGetContentUrls.Object, _mockDownloadContent.Object);
      await downloadAndStoreContent.DownloadAndStoreAsync();
      _mockDownloadContent.Verify(x => x.DownloadContentFromUrlAsync("http://www.url1.com"));
      _mockDownloadContent.Verify(x => x.DownloadContentFromUrlAsync("http://www.url2.com"));
    }
