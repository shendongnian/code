        /// <summary>
        /// Get the client IP address.
        /// </summary>
        private string GetClientIpAddress()
        {
            string result = string.Empty;
            try
            {
                OperationContext context = OperationContext.Current;
                MessageProperties messageProperties = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpointProperty = messageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                result = endpointProperty.Address;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return result;
        }
        /// <summary>
        /// Returns <code>true</code> if the current IP address is allowed
        /// to access the webservice method, <code>false</code> otherwise.
        /// </summary>
        private bool CheckIPAccessRestriction()
        {
            bool result = false;
            List<string> allowed = GetAllowedIpAddressesList();
            if (allowed.Count() == 0)
            {
                result = true;
            }
            else
            {
                var ip = GetClientIpAddress();
                result = allowed.Contains(ip);
            }
            return result;
        }
