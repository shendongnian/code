        private void MergeEventProperties(LogEventInfo logEvent)
        {
            foreach (var item in logEvent.Parameters)
            {
                if (item.GetType() == typeof(LogEventInfo))
                {
                    
                    foreach (var propertyItem in ((LogEventInfo)item).Properties)
                    {
                        logEvent.Properties.Remove(propertyItem.Key);
                        logEvent.Properties.Add(propertyItem);
                    }
                }
            }
        }
