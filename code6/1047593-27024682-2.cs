    using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "YourDomain"))
                    {
                        if (UserName.Contains("YourDomain\\"))
                        {
                            UserName = UserName.Replace("YourDomain\\", String.Empty);
                        }
                        //validate the credentials
                       bool IsValid = pc.ValidateCredentials(UserName, Password);
                    }
