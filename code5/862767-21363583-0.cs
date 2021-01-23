    form2.Show();
    form2.Invoke((MethodInvoker)delegate
    {
       Encoding charset = Encoding.GetEncoding("utf-8");
       HttpWebRequest SMSRequset =  (HttpWebRequest)WebRequest.Create("http://www.iam.ma/_layouts/SharepointFreeSms/EnvoyerSms.aspx");  
       SMSRequset.Method = "GET";
       SMSRequset.CookieContainer = cookies;
       HttpWebResponse SMSResponse = (HttpWebResponse)SMSRequset.GetResponse();
       System.IO.StreamReader reader2 = new System.IO.StreamReader(SMSResponse.GetResponseStream(), charset);
       form2.webBrowser1.DocumentText = reader2.ReadToEnd();
    });
