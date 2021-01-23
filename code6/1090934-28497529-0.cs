    using System;
    using Microsoft.TeamFoundation.Common;
    using Microsoft.TeamFoundation.Framework.Server;
    using Microsoft.TeamFoundation.VersionControl.Server;
    using System.IO;
    using System.Text.RegularExpressions;
    using Microsoft.TeamFoundation.Framework.Server.Alm;
    
    namespace TFS.CheckinPolicyOverrideEventHandler
    {
        public sealed class CheckinPolicyOverrideEventHandler : ISubscriber
        {
            public Type[] SubscribedTypes()
            {
                return new Type[1] { typeof(CheckinNotification) };
            }
            public EventNotificationStatus ProcessEvent(TeamFoundationRequestContext requestContext, NotificationType notificationType, object notificationEventArgs,
                                                    out int statusCode, out string statusMessage, out ExceptionPropertyCollection properties)
            {
                statusCode = 0;
                properties = null;
                statusMessage = String.Empty;
    
                try
                {
                if (notificationType == NotificationType.DecisionPoint && notificationEventArgs is CheckinNotification)
                {
                    CheckinNotification ev = notificationEventArgs as CheckinNotification;
                    if (ev != null && ev.PolicyOverrideInfo != null)
                    {
                        if (ev.PolicyOverrideInfo.PolicyFailures != null)
                        {
                            // One or more of the checkin policies have been overridden
                            // If all the files being checked in are in the published folder, then allow overridding the policies since those are installation packages
                            foreach (string file in ev.GetSubmittedItems(null))
                            {
                                if (!Regex.IsMatch(file, @"/published", RegexOptions.IgnoreCase) &&
                                    !Regex.IsMatch(Path.GetDirectoryName(file), @"/published", RegexOptions.IgnoreCase))
                                {
                                    statusCode = -1;
                                    break;
                                }
                            }
                            if (statusCode != 0)
                            {
                                // One or more of the checkin policies have been overridden and not all files are installation files (in the published folder)
                                statusMessage = Resource.CheckinCancelledStatusMessage;
                                foreach (PolicyFailureInfo policy in ev.PolicyOverrideInfo.PolicyFailures)
                                {
                                    statusMessage = String.Concat(statusMessage, "\n    > ", policy.PolicyName, ": ", policy.Message);
                                }
                                return EventNotificationStatus.ActionDenied;
                            }
                        }
                    }
                    return EventNotificationStatus.ActionPermitted;
                }
            }
            catch (Exception exception)
            {
                // decide what you want to do, if exception occurs
            }
            return EventNotificationStatus.ActionPermitted;
        }
        public string Name
        {
            get { return "TFS.CheckinPolicyOverrideEventHandler"; }
        }
        public SubscriberPriority Priority
        {
            get { return SubscriberPriority.Normal; }
        }
    }
}
