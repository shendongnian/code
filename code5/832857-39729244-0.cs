    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    public static partial class Log
    {
        /// <summary>
        /// Saves the exception details to ErrorLogging db with Low Priority
        /// </summary>
        /// <param name="ex">The exception.</param>
        public static void Save(this Exception ex)
        {
            Save(ex, ImpactLevel.Low, "");
        }
        /// <summary>
        /// Saves the exception details to ErrorLogging db with specified ImpactLevel
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="impactLevel">The Impact level.</param>
        public static void Save(this Exception ex, ImpactLevel impactLevel)
        {
            Save(ex, impactLevel,"");
        }
        /// <summary>
        /// Saves the exception details to ErrorLogging db with specified ImpactLevel and user message
        /// </summary>
        /// <param name="ex">The exception</param>
        /// <param name="impactLevel">The impact level.</param>
        /// <param name="errorDescription">The error Description.</param>
        public static void Save(this Exception ex, ImpactLevel impactLevel, string errorDescription)
        {
            using (var db = new ErrorLoggingDataContext())
            {
                Log log = new Log();
                if (errorDescription != null && errorDescription != "")
                {
                    log.ErrorShortDescription = errorDescription;
                }
                log.ExceptionType = ex.GetType().FullName;
                var stackTrace = new StackTrace(ex, true);
                var allFrames = stackTrace.GetFrames().ToList();
                foreach (var frame in allFrames)
                {
                    log.FileName = frame.GetFileName();
                    log.LineNumber = frame.GetFileLineNumber();
                    var method = frame.GetMethod();
                    log.MethodName = method.Name;
                    log.ClassName = frame.GetMethod().DeclaringType.ToString();
                }
                log.ImpactLevel = impactLevel.ToString();
                try
                {
                    log.ApplicationName = Assembly.GetCallingAssembly().GetName().Name;
                }
                catch
                {
                    log.ApplicationName = "";
                }
                log.ErrorMessage = ex.Message;
                log.StackTrace = ex.StackTrace;
                if (ex.InnerException != null)
                {
                    log.InnerException = ex.InnerException.ToString();
                    log.InnerExceptionMessage = ex.InnerException.Message;
                }
                //var methodsName = System.Reflection.MethodBase.GetCurrentMethod();
                //string projectName=System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
                string whosOnCookie = Email.FindCookieValue("whoson");
                if (!string.IsNullOrEmpty(whosOnCookie))
                {
                    log.WhosOnCookie = whosOnCookie;
                }
                string commercerserverId = Email.FindCookieValue("COMMERCE_SITE_Identity");
                if (!string.IsNullOrEmpty(commercerserverId))
                {
                    log.CommerceServerId = commercerserverId;
                }
                log.IpAddress = Email.GetIPAddress();
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    log.IsProduction = false;
                }
                try
                {
                    db.Logs.InsertOnSubmit(log);
                    db.SubmitChanges();
                }
                catch (Exception eex)
                {
                   
                }
            }
        }
    }
