                do
                {
                    var messages = _queue.GetMessages(32);
                    foreach (var msg in messages)
                    {
                        ProcessMessage(msg);
                        DeleteMessage(msg);
                    }
                    var approximateMessagesCount = _queue.FetchAttributes().ApproximateMessageCount.Value;
                    if (approximateMessagesCount == 0)
                    {
                        break;
                    }
                } while (true);
