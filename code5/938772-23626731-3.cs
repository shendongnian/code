     private async void LoadUserInfo()
            {
                var fb = new FacebookClient(App.AccessToken);
    
                fb.GetCompleted += (o, e) =>
                {
                    if (e.Error != null)
                    {
                        Dispatcher.BeginInvoke(() => MessageBox.Show(e.Error.Message));
                        return;
                    }
    
                    var result = (IDictionary<string, object>)e.GetResultData();
    
                    Dispatcher.BeginInvoke(async () =>
                    {    
                        var profilePictureUrl = string.Format("https://graph.facebook.com/{0}/picture?type={1}&access_token={2}", App.FacebookId, "normal", App.AccessToken);                    
    
                        this.ImgAvatar.Source = new BitmapImage(new Uri(profilePictureUrl));
                        this.TxtName.Text = String.Format("{0}", (string)result["name"]);                    
    
                       
                    });
                };
    
                await fb.GetTaskAsync("me");
            }
