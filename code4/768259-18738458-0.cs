    [Serializable]
            public sealed class BackgroundTaskDescription
            {
                
                public BackgroundTaskDescription()
                {
                    Subject = string.Empty;
                    Message = string.Empty;
                    dueTime = string.Empty;
                    Emails = new List<string>();
                }
    
                public string Subject { get; set; }
                public string Message { get; set; }
                public string dueTime { get; set; }
                public List<string> Emails { get; set; }
            }
