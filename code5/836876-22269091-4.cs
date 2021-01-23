            //copy properties and set the desired lifetime of refresh token
            var refreshTokenProperties = new AuthenticationProperties(context.Ticket.Properties.Dictionary)
            {
                IssuedUtc = context.Ticket.Properties.IssuedUtc,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(5) //SET DATETIME to 5 Minutes
                //ExpiresUtc = DateTime.UtcNow.AddMonths(3) 
            };
            /*CREATE A NEW TICKET WITH EXPIRATION TIME OF 5 MINUTES 
             *INCLUDING THE VALUES OF THE CONTEXT TICKET: SO ALL WE 
             *DO HERE IS TO ADD THE PROPERTIES IssuedUtc and 
             *ExpiredUtc to the TICKET*/
            var refreshTokenTicket = new AuthenticationTicket(context.Ticket.Identity, refreshTokenProperties);
            //saving the new refreshTokenTicket to a local var of Type ConcurrentDictionary<string,AuthenticationTicket>
            // consider storing only the hash of the handle
            RefreshTokens.TryAdd(guid, refreshTokenTicket);            
            context.SetToken(guid);
