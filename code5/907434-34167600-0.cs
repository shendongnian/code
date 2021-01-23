    using (var stream = new FileStream(imagePath, FileMode.Open))
                {
                    var result = service.SendTweetWithMedia(new SendTweetWithMediaOptions
                    {
                        Status = message,
                        Images = new Dictionary<string, Stream> { { "john", stream } }
                    });
                    lblResult.Text = result.Text.ToString();
                }
