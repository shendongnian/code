    using System;
    using System.Web.Mvc;
    using System.Net;
    using System.Linq;
    using System.Net.Sockets;
    using MyMvcApplication.Models.Entity;
    using MyMvcApplication.Utilities;
    
    namespace MyMvcApplication.Filters
    {
        /// <summary>
        /// 
        /// </summary>
        public class LoggerActionFilter : ActionFilterAttribute
        {
            private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                // Stores the Request in an Accessible object
                var request = filterContext.HttpContext.Request;
                var visitCount = Convert.ToInt64(filterContext.HttpContext.Session["LoggerActivityTracking"].ToString());
                // Generate an audit
                Portal_Logger aLogger = new Portal_Logger()
                {
                    // Your Logger Identifier     
                    LoggerId = Guid.NewGuid(),
                    //Logged On User Id
                    LogedUserId = Convert.ToInt32(filterContext.HttpContext.Session["LogedUserID"]),
                    // The IP Address of the Request
                    IPAddress = Convert.ToString(ipHostInfo.AddressList.FirstOrDefault(address => address.AddressFamily == AddressFamily.InterNetwork)),
                    //Get the Web Page name(from the URL that was accessed)
                    AreaAccessed = UserActivityUtility.GetWebPageName(request.RawUrl == "/"? "/Home/UserLandingPage" : request.RawUrl),
                    // Creates our Timestamp
                    Timestamp = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE),
                    VisitorSessionId = visitCount
                };
                
                // Stores the Logger in the Database
                using (IOTAssetEntities context = new IOTAssetEntities())
                {
                    if (aLogger.LogedUserId != null)
                    {
                        aLogger.LogedUserEmpId = context.D_EMP_MASTER
                            .Where(x => x.User_Id == aLogger.LogedUserId)
                            .Select(x => x.Emp_Id).FirstOrDefault();
                        aLogger.LogedUserEmpName = context.D_EMP_MASTER
                            .Where(x => x.User_Id == aLogger.LogedUserId)
                            .Select(x => x.Emp_Name).FirstOrDefault();
                        aLogger.AccessedType = aLogger.AreaAccessed.Contains("Report") ? "Report" : "Page";
                    }
                    context.Portal_Logger.Add(aLogger);
                    context.SaveChanges();
                }
                // Finishes executing the Logger as normal 
                base.OnActionExecuting(filterContext);
            }
    
        }
    }
