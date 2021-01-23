                List<string> foundIds = new List<string>();
                string outputDir = "/EXAMPLE/EXAMPLE/"; // your preferred Dir to save attachments to
                   
                List<Google.Apis.Gmail.v1.Data.Thread> resultThread = new List<Google.Apis.Gmail.v1.Data.Thread>();
                UsersResource.ThreadsResource.ListRequest requestThread = service.Users.Threads.List("me");
                
                do
                {
                    try
                    {
                        ListThreadsResponse responseThread = requestThread.Execute();
                        resultThread.AddRange(responseThread.Threads);
                        foreach (var item in responseThread.Threads )
                        {
                            foundIds.Add(item.Id);
                        }
                        requestThread.PageToken = responseThread.NextPageToken;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("An error occurred: " + e.Message);
                    }
                } while (!String.IsNullOrEmpty(requestThread.PageToken));
                try
                {
                    Message message = service.Users.Messages.Get("me", foundIds[0]).Execute();
                    IList<MessagePart> parts = message.Payload.Parts;
                    foreach (MessagePart part in parts)
                    {
                        if (!String.IsNullOrEmpty(part.Filename))
                        {
                            String attId = part.Body.AttachmentId;
                            MessagePartBody attachPart = service.Users.Messages.Attachments.Get("me", foundIds[0], attId).Execute();
                            // Converting from RFC 4648 base64 to base64url encoding
                            // see http://en.wikipedia.org/wiki/Base64#Implementations_and_history
                            String attachData = attachPart.Data.Replace('-', '+');
                            attachData = attachData.Replace('_', '/');
                            byte[] data = Convert.FromBase64String(attachData);
                            File.WriteAllBytes(Path.Combine(outputDir, part.Filename), data);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                }
