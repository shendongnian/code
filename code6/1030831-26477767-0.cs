    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Security;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.SharePoint.Client;
    using O365ProfileUpdate.UserProfileServiceRef;
    
        public class O365Helper
        {
            private readonly UserProfileService _userProfileService;
            private readonly Uri _targetAdminSite;
    
            public O365Helper(UserProfileService userProfileService, Uri targetAdminSite, string adminUsername,
                              string adminPassword)
            {
                _userProfileService = userProfileService;
                _targetAdminSite = targetAdminSite;
    
    
                var authenticated = AuthenticateAdministrator(adminUsername, adminPassword);
    
                if (!authenticated)
                    throw new UnauthorizedAccessException("Unable to authenticate administrator");
            }
    
            public PropertyData GetProfileProperty(string login, string propertyName)
            {
                var memLogin = GetMembershipLogin(login);
    
                return _userProfileService.GetUserPropertyByAccountName(memLogin, propertyName);
            }
    
            public bool UpdateProfileProperty(string login, string key, string value)
            {
                try
                {
                    var valueData = new ValueData {Value = value};
    
                    var newdata = new PropertyData[1];
                    newdata[0] = new PropertyData {Name = key, Values = new ValueData[1]};
                    newdata[0].Values[0] = valueData;
                    newdata[0].IsValueChanged = true;
    
                    var memLogin = GetMembershipLogin(login);
    
                    _userProfileService.ModifyUserPropertyByAccountName(memLogin, newdata);
                }
                catch
                {
                    return false;
                }
    
                return true;
            }
    
            private bool AuthenticateAdministrator(string login, string password)
            {
                try
                {
                    var securePassword = new SecureString();
                    foreach (char c in password)
                    {
                        securePassword.AppendChar(c);
                    }
    
                    var onlineCredentials = new SharePointOnlineCredentials(login, securePassword);
    
                    string authCookieValue = onlineCredentials.GetAuthenticationCookie(_targetAdminSite);
                    var cookieVal = authCookieValue.TrimStart("SPOIDCRL=".ToCharArray());
    
                    _userProfileService.CookieContainer = new CookieContainer();
                    _userProfileService.CookieContainer.Add(new Cookie(
                                                                "FedAuth",
                                                                cookieVal,
                                                                String.Empty,
                                                                _targetAdminSite.Authority));
                }
                catch
                {
                    return false;
                }
    
                return true;
            }
    
            private string GetMembershipLogin(string login)
            {
                return "i:0#.f|membership|" + login;
            }
        }
