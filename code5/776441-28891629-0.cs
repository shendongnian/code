            if (User.Identity.IsAuthenticated)
            {
                var identity = (FormsIdentity)User.Identity;    
                viewModel.UtcInactivityExpiryDate = identity.Ticket.Expiration.ToUniversalTime();                
            }
