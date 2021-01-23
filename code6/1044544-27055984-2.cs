    public void UserAuthMethod(UserAuthMethod userAuth)
            {
                WebClient webclient = new WebClient();
                Uri uristring = null;
                uristring = new Uri("http://startaxi.punct.ro/api/init/userAuth",UriKind.Absolute);//Please replace your URL here
                webclient.Headers["Content-type"] = "application/json";
                //content
                Dictionary<string, string> toSerialize = new Dictionary<string, string>();
                toSerialize.Add("email", userAuth.Email);
                toSerialize.Add("password", userAuth.Password);
                string JsonStringParams = JsonConvert.SerializeObject(toSerialize);
                
                webclient.UploadStringCompleted += wc_UploadStringCompleted;
                webclient.UploadStringAsync(uristring, "POST", JsonStringParams);
            }
    
            private void wc_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
            {
                //try
                {
    
                    if (e.Result != null)
                    {
                        string responce = e.Result.ToString();
                        //To Do Your functionality
                    }
                }
               // catch
                {
                }
            }
