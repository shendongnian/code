    private async Task Authenticate()
            {
                try
                {
                    _session = await App.FacebookSessionClient.LoginAsync("user_about_me,read_stream");
                    App.AccessToken = _session.AccessToken;
                    App.FacebookId = _session.FacebookId; 
                }
                catch (InvalidOperationException e)
                {
                    var messageBox = new OneButtonCustomMessageBox
                    {
                        TbMessageTitle = { Text = "Facebook Login Error" },
                        TbMessageContent = {Text = e.Message}
                    };
                    messageBox.Show();
                }
            }
