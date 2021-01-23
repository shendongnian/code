    protected void Button1_Click(object sender, EventArgs e)
            {
    
                string url = "https://api.appannie.com/v1/accounts?page_index=0";
                string id="",temp="";
    
                
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UseDefaultCredentials = true;
                request.Proxy = WebProxy.GetDefaultProxy();
                request.Credentials = new NetworkCredential("username", "pass");
                request.ContentType = "Accept: application/xml";
                request.Proxy.Credentials = CredentialCache.DefaultCredentials;
                request.Referer = "http://stackoverflow.com";
                request.Headers.Add("Authorization", "bearer ***********");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
    
                    // Pipes the stream to a higher level stream reader with the required encoding format.
                    StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                    temp = readStream.ReadToEnd();
    
                    //TextArea1.InnerText = temp + "\n";
                    string[] id_arr = temp.Split(',');
                    int count = 0;
                    while (count != id_arr.Length)
                    {
    
                        if (id_arr[count].Contains("account_id"))
                        {
                            id = id_arr[count];
                            count = id_arr.Length;
                            break;
                        }
    
                        count++;
                    }
                    id = id.Substring(id.IndexOf("account_id") + 13);
                    //TextArea1.InnerText += id;
    
                    
                    //Console.Write(readStream.ReadToEnd());
                    //response.Close();
                    response = null;
                    //readStream.Close();
                    request = null;
    
                    string date = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
    
                    string url2 = "https://api.appannie.com/v1/accounts/" + id + "/sales?break_down=application+date" +
                                                "&start_date="+date+
                                                "&end_date="+date+
                                                "&currency=USD" +
                                                "&countries=" +
                                                "&page_index=0";
    
               
                    TextArea1.InnerText = url2;
    
                    
                    request = (HttpWebRequest)WebRequest.Create(url2);
                    request.Proxy = WebProxy.GetDefaultProxy();
                    request.Proxy.Credentials = CredentialCache.DefaultCredentials;
                    request.Referer = "http://stackoverflow.com";
                    request.Headers.Add("Authorization", "bearer ************");
                    response = (HttpWebResponse)request.GetResponse();
                    
    
                    receiveStream = response.GetResponseStream();
    
                    // Pipes the stream to a higher level stream reader with the required encoding format.
                    readStream = new StreamReader(receiveStream, Encoding.UTF8);
                    temp = "";
                    temp = readStream.ReadToEnd();
                    //TextArea1.InnerText = temp;
    
                    string[] id_arr2 = temp.Split(',');
                    int count2 = 0;
                    string down = "";
                    string update = "";
                    while (count2 != id_arr2.Length)
                    {
    
                        if (id_arr2[count2].Contains("downloads"))
                        {
                            down = id_arr2[count2];
                            count2 = id_arr2.Length;
                            break;
                        }
    
                        count2++;
                    }
    
                    count2 = 0;
    
                    while (count2 != id_arr2.Length)
                    {
    
                        if (id_arr2[count2].Contains("update"))
                        {
                            update = id_arr2[count2];
                            count2 = id_arr2.Length;
                            break;
                        }
    
                        count2++;
                    }
    
    
                    down = down.Substring(down.IndexOf("downloads") + 12);
                    update = update.Substring(update.IndexOf("update") + 9);
                    
                    //TextArea1.InnerText = "downloads : "+down+ "----- update :" + update;
    
                    TextBox1.Text = down;
                    TextBox2.Text = update;
                     
    
                }
    }
