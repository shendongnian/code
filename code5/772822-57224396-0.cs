     string GetLogin(string s)
        {
            string regex = @"^(.*\\)?([^\@]*)(@.*)?$";
            return Regex.Replace(s, regex, "$2", RegexOptions.None);
        }
    using (PrincipalContext pcLocal = new PrincipalContext(ContextType.Machine))
                {
                    try
                    {
                                try
                                {
                                    if (null != group && pcLocal.ValidateCredentials($".\\{username}", password))
                                    {
                                        return GetLogin(findByIdentity.SamAccountName);
                                    }
                                }
                                catch (Exception)
                                {
                                    string user = GetLogin(username);
                                    if (null != group && pcLocal.ValidateCredentials(user, password))
                                    {
                                        return GetLogin(findByIdentity.SamAccountName);
                                    }
                                }
 
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
