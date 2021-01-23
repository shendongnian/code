    public static void GetBody(GmailService service, String userId, String messageId, String outputDir)
        {
            try
            {
                Message message = service.Users.Messages.Get(userId, messageId).Execute();
                Console.WriteLine(message.InternalDate);
                if (message.Payload.MimeType == "text/plain")
                {
                    byte[] data = FromBase64ForUrlString(message.Payload.Body.Data);
                    string decodedString = Encoding.UTF8.GetString(data);
                    Console.WriteLine(decodedString);
                }
                else
                {
                    IList<MessagePart> parts = message.Payload.Parts;
                    if (parts != null && parts.Count > 0)
                    {
                        foreach (MessagePart part in parts)
                        {
                            if (part.MimeType == "text/html")
                            {
                                byte[] data = FromBase64ForUrlString(part.Body.Data);
                                string decodedString = Encoding.UTF8.GetString(data);
                                Console.WriteLine(decodedString);
                            }
                        }
                    }
                }
                Console.WriteLine("----");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
