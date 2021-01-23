		[Test]
		public void WithVersion()
		{
			var queryResults = this.Client.Search<ElasticsearchProject>(s=>s
				.Version()
				.MatchAll()
			);
			Assert.True(queryResults.IsValid);
			Assert.Greater(queryResults.Total, 0);
			Assert.True(queryResults.Hits.All(h => !h.Version.IsNullOrEmpty()));
		}
