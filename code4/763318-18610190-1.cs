    public class EmailNotificationValidationRules
    {
        public static IEnumerable<Rule<EmailNotificationData>> Rules 
        {
            get
            {
                return new List<Rule<EmailNotificationData>>
                    {
                        new Rule<EmailNotificationData> { Test = data => data != null, Message = "No email notifacation data" },
                        new Rule<EmailNotificationData> { Test = data => !string.IsNullOrEmpty(data.Sender), Message = "No sender" },
                        new Rule<EmailNotificationData> { Test = data => data.ToRecipients != null, Message = "No recipients" }
                    };
            }
        }
    }
