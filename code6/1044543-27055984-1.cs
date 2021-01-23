    public void UserAuthMethod(UserAuthMethod userAuth)
            {
                WebClient webclient = new WebClient();
                Uri uristring = null;
                uristring = new Uri("http://startaxi.punct.ro/api/init/userAuth",UriKind.Absolute);//Please replace your URL here
                webclient.Headers["Content-type"] = "application/json";
                //content
                Dictionary<string, string> toSerialize = new Dictionary<string, string>();
                toSerialize.Add("email", "test@a.com");
                toSerialize.Add("password", "test");
                string JsonStringParams = JsonConvert.SerializeObject(toSerialize);
                //content end
                //string JsonStringParams = "{\"Email\":\"clientWindows@a.com\",\"Password\":\"47EC2DD791E31E2EF2076CAF64ED9B3D\"}";
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
