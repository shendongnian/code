	using System;
	using System.Threading;
	using System.Threading.Tasks;
	using Google;
	using Google.Apis.Auth.OAuth2;
	using Google.Apis.Calendar.v3;
	using Google.Apis.Calendar.v3.Data;
	using Google.Apis.Services;
	namespace Calendar.Sample
	{
		class Program
		{
			static void Main(string[] args)
			{
				UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
					new ClientSecrets
					{
						ClientId = "CLIENT_ID_HERE",
						ClientSecret = "CLIENT_SECRET_HERE",
					},
					new[] { CalendarService.Scope.Calendar },
					"user",
					CancellationToken.None).Result;
				// Create the service.
				var service = new CalendarService(new BaseClientService.Initializer()
				{
					HttpClientInitializer = credential,
					ApplicationName = "Calendar API Sample",
				});
				...
			}
		}
	}
