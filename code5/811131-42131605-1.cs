        public TeamFoundationIdentity GetUserByAccountName(string account)
        {
            var ims = _tfServer.GetService<IIdentityManagementService>();
            return ims.ReadIdentity(IdentitySearchFactor.DisplayName, account, MembershipQuery.Expanded, ReadIdentityOptions.ExtendedProperties);
        }
