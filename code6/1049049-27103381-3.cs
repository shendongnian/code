    string resourceUri = "https://outlook.office365.com";
            var signInUserId = ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userObjectId = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value;
            AuthenticationContext authContext = new AuthenticationContext(Settings.Authority, new NaiveSessionCache(signInUserId));
            string tokenx = await AuthHelper.AcquireTokenAsync(authContext, resourceUri, Settings.ClientId, new UserIdentifier(userObjectId,UserIdentifierType.UniqueId));
            
            System.Diagnostics.Debug.WriteLine("Token:" + tokenx);
            
                ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013);
                service.TraceListener = new EwsTrace();
                service.TraceEnabled = true;
                service.TraceFlags = TraceFlags.All;
                service.HttpHeaders.Add("Authorization", "Bearer " + tokenx);
                service.PreAuthenticate = true;
                service.SendClientLatencies = true;
                service.EnableScpLookup = false;
                service.Url = new Uri("https://outlook.office365.com/EWS/Exchange.asmx");
                
                ExFolder rootfolder = ExFolder.Bind(service, WellKnownFolderName.MsgFolderRoot);
            
            Console.WriteLine("The " + rootfolder.DisplayName + " has " + rootfolder.ChildFolderCount + " child folders.");
