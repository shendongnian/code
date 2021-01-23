            //Mediafire API Info
            private static string url = "HTTPS://www.mediafire.com/api/1.2/user/get_session_token.php?";
            private static string mf_email = "YOUR_EMAIL", mf_password = "YOUR_PASS", mf_app_id = "API_APP_ID", mf_api_key = "API_KEY", mf_signature = Mediafire_GetSignature();
            private static string mf_secret_key, mf_ekey, mf_pkey, mf_session, mf_response, mf_time, mf_callsig;
            private static string mf_folder_key = "FOLDER_ID"; // Folder to upload files to.
            // END
    
            public static string Mediafire_GetSignature()
            {
                string data = mf_email + mf_password + mf_app_id + mf_api_key;
                byte[] bytes = Encoding.UTF8.GetBytes(data);
                byte[] hash;
                using (SHA1 sha1 = new SHA1Managed())
                    hash = sha1.ComputeHash(bytes);
                string hashString = BitConverter.ToString(hash).Replace("-", "").ToLower();
                return hashString;
            }
            public static void Mediafire_GetInfo()
            {
                mf_response = Mediafire_GetSessionToken();
                if (!mf_response.ToLower().Contains("<result>success</result>"))
                {
                    MessageBox.Show("Mediafire_GetInfo: ERROR #1.");
                    Application.Exit();
                }
                else
                {
                    string[] sess = { "<session_token>", "</session_token>" };
                    mf_session = mf_response.Substring(mf_response.IndexOf(sess[0]) + sess[0].Length, mf_response.IndexOf(sess[1]) - mf_response.IndexOf(sess[0]) - sess[1].Length + 1);
                    /*string[] secret = { "<secret_key>", "</secret_key>" }; // token_version=2 only
                    mf_secret_key = mf_response.Substring(mf_response.IndexOf(secret[0]) + secret[0].Length, mf_response.IndexOf(secret[1]) - mf_response.IndexOf(secret[0]) - secret[1].Length + 1);*/
                    string[] pkey = { "<pkey>", "</pkey>" };
                    mf_pkey = mf_response.Substring(mf_response.IndexOf(pkey[0]) + pkey[0].Length, mf_response.IndexOf(pkey[1]) - mf_response.IndexOf(pkey[0]) - pkey[1].Length + 1);
                    string[] ekey = { "<ekey>", "</ekey>" };
                    mf_ekey = mf_response.Substring(mf_response.IndexOf(ekey[0]) + ekey[0].Length, mf_response.IndexOf(ekey[1]) - mf_response.IndexOf(ekey[0]) - ekey[1].Length + 1);
                    /*string[] time = { "<time>", "</time>" }; // token_version=2 only
                    mf_time = mf_response.Substring(mf_response.IndexOf(time[0]) + time[0].Length, mf_response.IndexOf(time[1]) - mf_response.IndexOf(time[0]) - time[1].Length + 1);*/
                    CopyToClipboard(mf_session);
                }
                if (mf_session == null || /*mf_secret_key == null || */mf_pkey == null || mf_ekey == null/* || mf_time == null*/)
                {
                    MessageBox.Show("Mediafire_GetInfo: ERROR #2.");
                    Application.Exit();
                }
                if (FirstGetInfo)
                {
                    MessageBox.Show("Connected to Mediafire successfully..");
                    FirstGetInfo = false;
                }
            }
    
            public static string Mediafire_GetSessionToken()
            {
                try
                {
                    string posturl = url + "signature=" + mf_signature + "&email=" + mf_email + "&password=" + mf_password + "&application_key=" + mf_api_key + "&application_id=" + mf_app_id + "&token_version=1&response_format=xml";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(posturl);
                    byte[] bytes;
                    bytes = System.Text.Encoding.ASCII.GetBytes(posturl);
                    request.ContentType = "text/xml; encoding='utf-8'";
                    request.ContentLength = bytes.Length;
                    request.Method = "POST";
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                    HttpWebResponse response;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Stream responseStream = response.GetResponseStream();
                        string responseStr = new StreamReader(responseStream).ReadToEnd();
                        return responseStr;
                    }
                }
                catch (Exception s)
                {
                    MessageBox.Show("Session Token Error. " + s.Message);
                }
                return null;
            }
