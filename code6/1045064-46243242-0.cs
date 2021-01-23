                    Microsoft.ServiceBus.Messaging.QueueDescription qd = myMicrosoftdotServiceBusdotNamespaceManager.GetQueue(qName);
                    string deadLetterQueueName = QueueClient.FormatDeadLetterPath(qd.Path);
                    int activeMessageCount = qd.MessageCountDetails.ActiveMessageCount;
                    int deadLetterMessageCount = qd.MessageCountDetails.DeadLetterMessageCount;
                    int scheduledMessageCount = qd.MessageCountDetails.ScheduledMessageCount;
                    int transferDeadLetterMessageCount = qd.MessageCountDetails.TransferDeadLetterMessageCount;
                    int transferMessageCount = qd.MessageCountDetails.TransferMessageCount;
