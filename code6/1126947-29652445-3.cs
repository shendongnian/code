    public static List<Contact> GetUsers(Uri requestUri, ICredentials credentials, string filter = "")
    {
            ClientContext context;
            var users = new List<Contact>();
            if (ClientContextUtilities.TryResolveClientContext(requestUri, out context, credentials))
            {
                var userProfilesResult = new List<PersonProperties>();
                using (context)
                {
                    var web = context.Web;
                    var peopleManager = new PeopleManager(context);
                    var siteUsers = from user in web.SiteUsers
                        where user.PrincipalType == Microsoft.SharePoint.Client.Utilities.PrincipalType.User
                        select user;
                    var usersResult = context.LoadQuery(siteUsers);
                    context.ExecuteQuery();
                    foreach (var user in usersResult)
                    {
                        if (user.Title.ToLower().Contains(filter.ToLower()) && !users.Any(x => x.FullName == user.Title))
                        {
                            var userProfile = peopleManager.GetPropertiesFor(user.LoginName);
                            context.Load(userProfile);
                            userProfilesResult.Add(userProfile);
                        }
                    }
                    context.ExecuteQuery();
                  
                    var result = from userProfile in userProfilesResult 
                                 where userProfile.ServerObjectIsNull != null && userProfile.ServerObjectIsNull.Value != true
                            select new Contact() {
                                FullName = userProfile.Title,
                                EmailAddress = userProfile.Email,
                                Position = userProfile.IsPropertyAvailable("Title") ? userProfile.Title : string.Empty,
                                PhoneNumber = userProfile.IsPropertyAvailable("UserProfileProperties") && userProfile.UserProfileProperties.ContainsKey("WorkPhone") ? userProfile.UserProfileProperties["WorkPhone"] : string.Empty
                            };
                    users = result.ToList();
                }
            }
            return users;
     }
