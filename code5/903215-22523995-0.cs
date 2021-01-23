    protected void btn_ShowCust_Click(object sender, EventArgs e)
    {
        try
        {
            string url = clsGuid.GetAPI() + "/service/service/student/search/" + txtstuname.Text.Trim();
            HttpWebRequest reque = (HttpWebRequest)HttpWebRequest.Create(url);
            reque.Method = "GET";
            reque.Accept = "application/json";
            reque.ContentType = "application/json";//application/x-www-form-urlencoded
            reque.UserAgent = "Java/1.6.0_22";
            reque.AuthenticationLevel =   System.Net.Security.AuthenticationLevel.MutualAuthRequested;
            reque.Credentials = new NetworkCredential("abcd", "123456");
            reque.PreAuthenticate = true;
            reque.KeepAlive = true;
            reque.Headers["Authorization"] = "Basic ERTGFEDCVTY=";
                HttpWebResponse response = (HttpWebResponse)reque.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream streamResponse = response.GetResponseStream();
                StreamReader streamRead = new StreamReader(streamResponse);
                using (var twitpicResponse = (HttpWebResponse)reque.GetResponse())
                {
                    using (var reader = new StreamReader(twitpicResponse.GetResponseStream()))
                    {
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        var objText = reader.ReadToEnd();
                        List<RootObject> myojb = js.Deserialize<List<RootObject>>(objText);
                        DataTable dt = new DataTable();      
                        dt.Columns.Add("FirstName", typeof (string));
                        dt.Columns.Add("LastName", typeof (string));
                                                                  
                         int countvalue = myojb.Count;                         
                          for (int i = 0; i < countvalue; i++)
                            {
                                //Need to display the data in GRIDVIEW...
                                //FirstName =dt.Rows.Add(myojb[i].firstName).ToString();
                                //LastName = dt.Rows.Add(myojb[i].lastName).ToString(); 
                                and so on...
                            }
                          gvRecipient.DataSource = dt;
                          gvRecipient.DataBind();
                    }
                }
            }
        }
        catch
        {
            Msg.InnerHtml = "<div class='msg-error'>We are facing some technical issues in processing your request. We will make it up quickly. Please try after some time.</div>";
        }
    }
