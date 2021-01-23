    using System;       
    namespace MyMvcApplication.Utilities
    {
        public static class UserActivityUtility
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="pageName"></param>
            /// <returns></returns>
            public static string GetWebPageName(string pageName)
            {
                string formattedPageName = string.Empty;
                //For All user web pages
                if (pageName.Contains("UserLandingPage"))
                {
                    formattedPageName = "Home - App Management";
                }            
    		    //For Report Web Pages 
                else if (pageName.Contains("AppUtilization"))
                {
                    formattedPageName = "Applocation Utilization Report";
                }           
                else if (pageName.Contains("AlertReport"))
                {
                    formattedPageName = "Alert Report";
                }            
                else if (pageName.Contains("DetailedReport"))
                {
                    formattedPageName = "Detailed Report";
                }            
                //For Admin Web Pages            
                else if (pageName.Contains("CreateUser"))
                {
                    formattedPageName = "Admin - Create User";
                }           
                else if (pageName.Contains("UpdateUserDetails"))
                {
                    formattedPageName = "Admin - Update User Details";
                }
                else if (pageName.Contains("EditUser"))
                {
                    formattedPageName = "Admin - Edit User";
                }           
                else
                {
                    formattedPageName = pageName;
                }
                return formattedPageName;
            }
        }
    }
