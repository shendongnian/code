        using System.DirectoryServices;
        using System.DirectoryServices.AccountManagement;
        ...
        protected static UserPrincipal QueryFilterUsers(string FilterFullName, string FilterDescription, string FilterLogin, string FilterPhone, string FilterEmail)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, _Domain);
            UserPrincipal _UserPrincipal = new UserPrincipal(ctx);
            _UserPrincipal.SamAccountName = "*" + ((!string.IsNullOrEmpty(FilterLogin)) ? FilterLogin.Trim() + "*" : "");
            if (!string.IsNullOrEmpty(FilterFullName)) _UserPrincipal.DisplayName = "*" + FilterFullName.Trim() + "*";
            if (!string.IsNullOrEmpty(FilterDescription)) _UserPrincipal.Description = "*" + FilterDescription.Trim() + "*";
            if (!string.IsNullOrEmpty(FilterPhone)) _UserPrincipal.VoiceTelephoneNumber = "*" + FilterPhone.Trim() + "*" ;
            if (!string.IsNullOrEmpty(FilterEmail)) _UserPrincipal.EmailAddress = "*" + FilterEmail.Trim() + "*";
            return _UserPrincipal;
        }
        //Получение списков
        public static List<Principal> GetUsersPrincipalList(string FilterFullName, string FilterDescription, string FilterLogin, string FilterPhone, string FilterEmail)
        {
            PrincipalSearcher _PrincipalSearcher = new PrincipalSearcher();
            _PrincipalSearcher.QueryFilter = QueryFilterUsers(FilterFullName, FilterDescription, FilterLogin, FilterPhone, FilterEmail);
            (_PrincipalSearcher.GetUnderlyingSearcher() as DirectorySearcher).PageSize = _PageSize;
            (_PrincipalSearcher.GetUnderlyingSearcher() as DirectorySearcher).SizeLimit = _SizeLimit;
            return _PrincipalSearcher.FindAll().ToList();
        }
