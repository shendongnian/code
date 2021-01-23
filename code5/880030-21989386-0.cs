        public static string CreateUserAndAccount(string userName, string password, object propertyValues = null, bool requireConfirmationToken = false)
        {
            ExtendedMembershipProvider provider = VerifyProvider();
            Debug.Assert(provider != null); // VerifyProvider checks this
            IDictionary<string, object> values = null;
            if (propertyValues != null)
            {
                values = new RouteValueDictionary(propertyValues);
            }
            return provider.CreateUserAndAccount(userName, password, requireConfirmationToken, values);
        }
