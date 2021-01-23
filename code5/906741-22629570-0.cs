    [Test]
        public async void GetSettingsRequest()
		{
            var getSettingsResponse = await api.GetSettings();
			Assert.IsNotNull (getSettingsResponse);
			Assert.IsTrue (getSettingsResponse.Success);
			Assert.IsNotNullOrEmpty (getSettingsResponse.Email);
		}
