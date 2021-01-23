		public async Task 
		Run() {
			UserCredential credential;
			using (var stream = new FileStream("Aggregate Volumes MTFE Client Secret.json", FileMode.Open, FileAccess.Read)) {
				credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
					GoogleClientSecrets.Load(stream).Secrets,
					new[] {PredictionService.Scope.Prediction},
					"user", CancellationToken.None );
				}
			var service =
				new PredictionService(
					new BaseClientService.Initializer() {
						HttpClientInitializer = credential,
						ApplicationName = "Aggregate Volumes MTFE"
						}
					);
			try {
				var pre = service.Trainedmodels.List("1043149216958");
				var response = pre.Execute();
				}
			catch (Exception e) { 
				Console.WriteLine("An error occurred: " + e.Message); 
				}
			}
    
