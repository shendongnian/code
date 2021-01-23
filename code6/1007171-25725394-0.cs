    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using Xanico.Core.Utilities;
    
    namespace Xanico.Core
    {
        /// <summary>
        /// Logging operations
        /// </summary>
        public static class Logger
        {
            // Note: The actual limit is higher than this, but different Microsoft operating systems actually have
            //       different limits. So just use 30,000 to be safe.
            private const int MaxEventLogEntryLength = 30000;
    
            /// <summary>
            /// Gets or sets the source/caller. When logging, this logger class will attempt to get the
            /// name of the executing/entry assembly and use that as the source when writing to a log.
            /// In some cases, this class can't get the name of the executing assembly. This only seems
            /// to happen though when the caller is in a separate domain created by its caller. So,
            /// unless you're in that situation, there is no reason to set this. However, if there is
            /// any reason that the source isn't being correctly logged, just set it here when your
            /// process starts.
            /// </summary>
            public static string Source { get; set; }
    
            /// <summary>
            /// Logs the message, but only if debug logging is true.
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="debugLoggingEnabled">if set to <c>true</c> [debug logging enabled].</param>
            /// <param name="source">The name of the app/process calling the logging method. If not provided,
            /// an attempt will be made to get the name of the calling process.</param>
            public static void LogDebug(string message, bool debugLoggingEnabled, string source = "")
            {
                if (debugLoggingEnabled == false) { return; }
    
                Log(message, EventLogEntryType.Information, source);
            }
    
            /// <summary>
            /// Logs the information.
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="source">The name of the app/process calling the logging method. If not provided,
            /// an attempt will be made to get the name of the calling process.</param>
            public static void LogInformation(string message, string source = "")
            {
                Log(message, EventLogEntryType.Information, source);
            }
    
            /// <summary>
            /// Logs the warning.
            /// </summary>
            /// <param name="message">The message.</param>
            /// <param name="source">The name of the app/process calling the logging method. If not provided,
            /// an attempt will be made to get the name of the calling process.</param>
            public static void LogWarning(string message, string source = "")
            {
                Log(message, EventLogEntryType.Warning, source);
            }
    
            /// <summary>
            /// Logs the exception.
            /// </summary>
            /// <param name="ex">The ex.</param>
            /// <param name="source">The name of the app/process calling the logging method. If not provided,
            /// an attempt will be made to get the name of the calling process.</param>
            public static void LogException(Exception ex, string source = "")
            {
                if (ex == null) { throw new ArgumentNullException("ex"); }
    
                if (Environment.UserInteractive)
                {
                    Console.WriteLine(ex.ToString());
                }
    
                Log(ex.ToString(), EventLogEntryType.Error, source);
            }
    
            /// <summary>
            /// Recursively gets the properties and values of an object and dumps that to the log.
            /// </summary>
            /// <param name="theObject">The object to log</param>
            [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Xanico.Core.Logger.Log(System.String,System.Diagnostics.EventLogEntryType,System.String)")]
            [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "object")]
            public static void LogObjectDump(object theObject, string objectName, string source = "")
            {
                const int objectDepth = 5;
                string objectDump = ObjectDumper.GetObjectDump(theObject, objectDepth);
    
                string prefix = string.Format(CultureInfo.CurrentCulture,
                                              "{0} object dump:{1}",
                                              objectName,
                                              Environment.NewLine);
    
                Log(prefix + objectDump, EventLogEntryType.Warning, source);
            }
    
            private static void Log(string message, EventLogEntryType entryType, string source)
            {
                // Note: I got an error that the security log was inaccessible. To get around it, I ran the app as administrator
                //       just once, then I could run it from within VS.
    
                if (string.IsNullOrWhiteSpace(source))
                {
                    source = GetSource();
                }
    
                string possiblyTruncatedMessage = EnsureLogMessageLimit(message);
                EventLog.WriteEntry(source, possiblyTruncatedMessage, entryType);
    
                // If we're running a console app, also write the message to the console window.
                if (Environment.UserInteractive)
                {
                    Console.WriteLine(message);
                }
            }
    
            private static string GetSource()
            {
                // If the caller has explicitly set a source value, just use it.
                if (!string.IsNullOrWhiteSpace(Source)) { return Source; }
    
                try
                {
                    var assembly = Assembly.GetEntryAssembly();
    
                    // GetEntryAssembly() can return null when called in the context of a unit test project.
                    // That can also happen when called from an app hosted in IIS, or even a windows service.
    
                    if (assembly == null)
                    {
                        assembly = Assembly.GetExecutingAssembly();
                    }
    
    
                    if (assembly == null)
                    {
                        // From http://stackoverflow.com/a/14165787/279516:
                        assembly = new StackTrace().GetFrames().Last().GetMethod().Module.Assembly;
                    }
    
                    if (assembly == null) { return "Unknown"; }
    
                    return assembly.GetName().Name;
                }
                catch
                {
                    return "Unknown";
                }
            }
    
            // Ensures that the log message entry text length does not exceed the event log viewer maximum length of 32766 characters.
            private static string EnsureLogMessageLimit(string logMessage)
            {
                if (logMessage.Length > MaxEventLogEntryLength)
                {
                    string truncateWarningText = string.Format(CultureInfo.CurrentCulture, "... | Log Message Truncated [ Limit: {0} ]", MaxEventLogEntryLength);
    
                    // Set the message to the max minus enough room to add the truncate warning.
                    logMessage = logMessage.Substring(0, MaxEventLogEntryLength - truncateWarningText.Length);
    
                    logMessage = string.Format(CultureInfo.CurrentCulture, "{0}{1}", logMessage, truncateWarningText);
                }
    
                return logMessage;
            }
        }
    }
