    private void downloadImage(string imageURL, string[] hamBurgerMenu)
            {
                string ext = Path.GetExtension(imageURL.Trim());
                try
                {
                    WebClient client = new WebClient();
                    client.OpenReadCompleted += (s, e) =>
                    {
                        if (e.Error == null)
                        {
                            Deployment.Current.Dispatcher.BeginInvoke(async () =>
                            {
                                await saveImage(e.Result, imageURL);
                            });
                        }
                        else
                        {
                           //Download Image Not Found
                        }
                    };
                    client.OpenReadAsync(new Uri(imageURL, UriKind.Absolute));
                }
                catch (Exception e)
                {
                    //Download Error
                }
            }
