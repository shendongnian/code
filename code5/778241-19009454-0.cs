          const string CallbackParameter = "callback";
          const string Endpoint = "https://www.google.com/accounts/o8/id";
          using (var openid = new OpenIdRelyingParty())
          {
                var callbackUrl = new Uri(string.Format("{0}?{1}=true", _context.RequestUri.AbsoluteUri, CallbackParameter));
                var authRequest = openid.CreateRequest(Endpoint, new Realm(string.Format("{0}://{1}", _context.RequestUri.Scheme, _context.RequestUri.Authority)), callbackUrl);
                // Tell Google what we want
                var fetch = new FetchRequest();
                fetch.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
                fetch.Attributes.AddRequired(WellKnownAttributes.Name.First);
                fetch.Attributes.AddRequired(WellKnownAttributes.Name.Last);
                authRequest.AddExtension(fetch);
                var response = authRequest.RedirectingResponse;
                var location = response.Headers["Location"];
                var fetch = response.GetExtension<FetchResponse>();
                if (fetch != null)
                {
                    Username = fetch.GetAttributeValue(WellKnownAttributes.Contact.Email);
                    Email = fetch.GetAttributeValue(WellKnownAttributes.Contact.Email);
                    FirstName = fetch.GetAttributeValue(WellKnownAttributes.Name.First);
                    LastName = fetch.GetAttributeValue(WellKnownAttributes.Name.Last);
                }
          }
