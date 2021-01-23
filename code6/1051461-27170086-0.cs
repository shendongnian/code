        /// <summary>
        ///   Renews the token (if it is near expiration or has expired)
        /// </summary>
        public void RenewTokenIfRequired()
        {
            if (null == _proxy.SecurityTokenResponse
                || !(DateTime.UtcNow.AddMinutes(15) >= _proxy.SecurityTokenResponse.Response.Lifetime.Expires)) return;
            try
            {
                _proxy.Authenticate();
            }
            catch (CommunicationException)
            {
                if (null == _proxy.SecurityTokenResponse ||
                    DateTime.UtcNow >= _proxy.SecurityTokenResponse.Response.Lifetime.Expires)
                    throw;
                // Ignore the exception 
            }
        }
