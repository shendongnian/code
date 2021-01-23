        public static bool ValidateUser(string username, string password, string companyName)
        {
            int companyId = MyRepository.GetCompanyIdByName(companyName);
            int? userId = companyId == 0 ? null : MyRepository.GetUserId(username, companyId);
            if (userId.HasValue && userId.Value != 0)
            {
                var userKey = username + "@" + companyName.ToLower();
                return WebSecurity.Login(userKey, password);
            }
            else
            {
                return false;
            }
        }
