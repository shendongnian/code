            if (Utility.isInternetAvailable())
            {
                try { MainPage.StartAnimation();
                MainPage.loaderGrid.Visibility = Visibility.Visible;
                }
                catch
                {
                    setAnimation();
                    StartAnimation();
                    loaderGrid.Visibility = Visibility.Visible;
                }
                string token = response.Substring(response.IndexOf('=') + 1);
                string fbGetInfo = "https://graph.facebook.com/me?access_token=" + token;
                HttpResponseMessage msg = await new HttpClient().GetAsync(new Uri(fbGetInfo), HttpCompletionOption.ResponseContentRead);
                if (msg.IsSuccessStatusCode)
                {
                    try
                    {
                        string fbData = await msg.Content.ReadAsStringAsync();
                        JObject j = JObject.Parse(fbData);
                        string fbId = j["id"].ToString();
                        txt_user_Name.Text = fbId;
                        txt_user_Name.Visibility = Visibility.Collapsed;
                        txt_first_Name.Text = j["first_name"].ToString();
                        txt_last_Name.Text = j["last_name"].ToString();
                        txt_email_Address.Text = j["email"].ToString();
                        txt_retype_email_Address.Text = j["email"].ToString();
                        gender = j["gender"].ToString();
                        if (gender.Equals("male", StringComparison.OrdinalIgnoreCase) || gender.Equals("boy", StringComparison.OrdinalIgnoreCase))
                        {
                            boy.Visibility = Visibility.Collapsed;
                            boySelected.Visibility = Visibility.Visible;
                            girlSelected.Visibility = Visibility.Collapsed;
                            girl.Visibility = Visibility.Visible;
                        }
                        else if (gender.Equals("female", StringComparison.OrdinalIgnoreCase) || gender.Equals("girl", StringComparison.OrdinalIgnoreCase))
                        {
                            girlSelected.Visibility = Visibility.Visible;
                            boySelected.Visibility = Visibility.Collapsed;
                            girl.Visibility = Visibility.Collapsed;
                            boy.Visibility = Visibility.Visible;
                        }
                    }
                    catch { }
enter code here
