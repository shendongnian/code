    RestRequest request = new RestRequest("your url", Method.POST);
                request.AddParameter("key", value);
                RestClient restClient = new RestClient();
                restClient.ExecuteAsync(request, (response) =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        StoryBoard2.Begin();
                        string result = response.Content;
                        if (result.Equals("success"))
                            message.Text = "Review submitted successfully!";
                        else
                            message.Text = "Review could not be submitted.";
                        indicator.IsRunning = false;
                    }
                    else
                    {
                        StoryBoard2.Begin();
                        message.Text = "Review could not be submitted.";
                    }
                });
