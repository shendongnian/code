    public class ActiveDirectoryHelper
    {
        private DirectoryEntry _directoryEntry = null;
        private DirectoryEntry SearchRoot
        {
            get
            {
                if (_directoryEntry == null)
                {
                    using (HostingEnvironment.Impersonate())
                    {
                        _directoryEntry = new DirectoryEntry(LDAPPath);//, LDAPUser, LDAPPassword, AuthenticationTypes.Secure);
                    }
                }
                return _directoryEntry;
            }
        }
        private String LDAPPath
        {
            get
            {
                return ConfigurationManager.AppSettings["LDAPPath"];
            }
        }
        //private String LDAPUser
        //{
        //    get
        //    {
        //        return ConfigurationManager.AppSettings["LDAPUser"];
        //    }
        //}
        //private String LDAPPassword
        //{
        //    get
        //    {
        //        return ConfigurationManager.AppSettings["LDAPPassword"];
        //    }
        //}
        private String LDAPDomain
        {
            get
            {
                return ConfigurationManager.AppSettings["LDAPDomain"];
            }
        }
        internal ADUserDetail GetUserByFullName(String userName)
        {
            try
            {
                using (HostingEnvironment.Impersonate())
                {
                    _directoryEntry = null;
                    DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);
                    directorySearch.Filter = "(&(objectClass=user)(cn=" + userName + "))";
                    SearchResult results = directorySearch.FindOne();
                    if (results != null)
                    {
                        DirectoryEntry user = new DirectoryEntry(results.Path);// LDAPUser, LDAPPassword);
                        return ADUserDetail.GetUser(user);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ADUserDetail GetUserByLoginName(String userName)
        {
           
            try
            {
                using (HostingEnvironment.Impersonate())
                {
                    // This code runs as the application pool user
                    _directoryEntry = null;
                    string nn = "LDAP://PRIME.local/DC=PRIME,DC=local";
                    DirectoryEntry SearchRoot2 = new DirectoryEntry(nn);
                    DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);
                    directorySearch.Filter = "(&(objectClass=user)(SAMAccountName=" + userName + "))";
                    SearchResult results = directorySearch.FindOne();
                    if (results != null)
                    {
                        DirectoryEntry user = new DirectoryEntry(results.Path);//, LDAPUser, LDAPPassword);
                        return ADUserDetail.GetUser(user);
                    }
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ADUserDetail GetUserDetailsByFullName(String FirstName, String MiddleName, String LastName)
        {
            //givenName
            //    initials
            //    sn
            //(initials=" + MiddleName + ")(sn=" + LastName + ")
            try
            {
                using (HostingEnvironment.Impersonate())
                {
                    _directoryEntry = null;
                    DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);
                    //directorySearch.Filter = "(&(objectClass=user)(givenName=" + FirstName + ") ())";
                    if (FirstName != "" && MiddleName != "" && LastName != "")
                    {
                        directorySearch.Filter = "(&(objectClass=user)(givenName=" + FirstName + ")(initials=" + MiddleName + ")(sn=" + LastName + "))";
                    }
                    else if (FirstName != "" && MiddleName != "" && LastName == "")
                    {
                        directorySearch.Filter = "(&(objectClass=user)(givenName=" + FirstName + ")(initials=" + MiddleName + "))";
                    }
                    else if (FirstName != "" && MiddleName == "" && LastName == "")
                    {
                        directorySearch.Filter = "(&(objectClass=user)(givenName=" + FirstName + "))";
                    }
                    else if (FirstName != "" && MiddleName == "" && LastName != "")
                    {
                        directorySearch.Filter = "(&(objectClass=user)(givenName=" + FirstName + ")(sn=" + LastName + "))";
                    }
                    else if (FirstName == "" && MiddleName != "" && LastName != "")
                    {
                        directorySearch.Filter = "(&(objectClass=user)(initials=" + MiddleName + ")(sn=" + LastName + "))";
                    }
                    SearchResult results = directorySearch.FindOne();
                    if (results != null)
                    {
                        DirectoryEntry user = new DirectoryEntry(results.Path);//, LDAPUser, LDAPPassword);
                        return ADUserDetail.GetUser(user);
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// This function will take a DL or Group name and return list of users
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public List<ADUserDetail> GetUserFromGroup(String groupName)
        {
            List<ADUserDetail> userlist = new List<ADUserDetail>();
            try
            {
                using (HostingEnvironment.Impersonate())
                {
                    _directoryEntry = null;
                    DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);
                    directorySearch.Filter = "(&(objectClass=group)(SAMAccountName=" + groupName + "))";
                    SearchResult results = directorySearch.FindOne();
                    if (results != null)
                    {
                        DirectoryEntry deGroup = new DirectoryEntry(results.Path);//, LDAPUser, LDAPPassword);
                        System.DirectoryServices.PropertyCollection pColl = deGroup.Properties;
                        int count = pColl["member"].Count;
                        for (int i = 0; i < count; i++)
                        {
                            string respath = results.Path;
                            string[] pathnavigate = respath.Split("CN".ToCharArray());
                            respath = pathnavigate[0];
                            string objpath = pColl["member"][i].ToString();
                            string path = respath + objpath;
                            DirectoryEntry user = new DirectoryEntry(path);//, LDAPUser, LDAPPassword);
                            ADUserDetail userobj = ADUserDetail.GetUser(user);
                            userlist.Add(userobj);
                            user.Close();
                        }
                    }
                    return userlist;
                }
            }
            catch (Exception ex)
            {
                return userlist;
            }
        }
        #region Get user with First Name
        public List<ADUserDetail> GetUsersByFirstName(string fName)
        {
            using (HostingEnvironment.Impersonate())
            {
                //UserProfile user;
                List<ADUserDetail> userlist = new List<ADUserDetail>();
                string filter = "";
                _directoryEntry = null;
                DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);
                directorySearch.Asynchronous = true;
                directorySearch.CacheResults = true;
                filter = string.Format("(givenName={0}*", fName);
                //            filter = "(&(objectClass=user)(objectCategory=person)(givenName="+fName+ "*))";
                directorySearch.Filter = filter;
                SearchResultCollection userCollection = directorySearch.FindAll();
                foreach (SearchResult users in userCollection)
                {
                    DirectoryEntry userEntry = new DirectoryEntry(users.Path);//, LDAPUser, LDAPPassword);
                    ADUserDetail userInfo = ADUserDetail.GetUser(userEntry);
                    userlist.Add(userInfo);
                }
                directorySearch.Filter = "(&(objectClass=group)(SAMAccountName=" + fName + "*))";
                SearchResultCollection results = directorySearch.FindAll();
                if (results != null)
                {
                    foreach (SearchResult r in results)
                    {
                        DirectoryEntry deGroup = new DirectoryEntry(r.Path);//, LDAPUser, LDAPPassword);
                        ADUserDetail agroup = ADUserDetail.GetUser(deGroup);
                        userlist.Add(agroup);
                    }
                }
                return userlist;
            }
        }
        #endregion
        #region AddUserToGroup
        public bool AddUserToGroup(string userlogin, string groupName)
        {
            try
            {
                using (HostingEnvironment.Impersonate())
                {
                    _directoryEntry = null;
                    ADManager admanager = new ADManager(LDAPDomain);//, LDAPUser, LDAPPassword);
                    admanager.AddUserToGroup(userlogin, groupName);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
        #region RemoveUserToGroup
        public bool RemoveUserToGroup(string userlogin, string groupName)
        {
            try
            {
                using (HostingEnvironment.Impersonate())
                {
                    _directoryEntry = null;
                    ADManager admanager = new ADManager("xxx");// LDAPUser, LDAPPassword);
                    admanager.RemoveUserFromGroup(userlogin, groupName);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
